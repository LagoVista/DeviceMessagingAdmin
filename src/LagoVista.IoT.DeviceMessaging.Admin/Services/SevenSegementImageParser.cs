// --- BEGIN CODE INDEX META (do not edit) ---
// ContentHash: 3969d428627ef8d26b091a1c6cfcf3d2b9b442623f9f09a685def65ba3f21ad0
// IndexVersion: 0
// --- END CODE INDEX META ---
using LagoVista.Core.Validation;
using LagoVista.IoT.DeviceMessaging.Admin.Models;
using LagoVista.IoT.DeviceMessaging.Models;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Processing;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace LagoVista.IoT.DeviceMessaging.Admin.Services
{
    public class SevenSegementImageParser
    {
        class Segement
        {
            readonly int _top;
            readonly int _left;
            readonly int _bottom;
            readonly int _right;
            readonly string _name;

            public Segement(String name, int left, int top, int right, int bottom)
            {
                _name = name;
                _top = top;
                _left = left;
                _bottom = bottom;
                _right = right;
            }

            public byte IsEnabled(Image img)
            {
                using (var cloned = img.Clone(m => m.Crop(new Rectangle(_left, _top, _right - _left, _bottom - _top))))
                {
                    var bldr = new StringBuilder();
                    long segTotal = 0;
                    long segOn = 0;
                    using (var ms = new MemoryStream())
                    {
                        cloned.SaveAsBmp(ms);
                        var buffer = ms.ToArray();
                        for (int y = 0; y < cloned.Height; ++y)
                        {
                            for (int x = 0; x < (cloned.Width * 3); x += 3)
                            {
                                var idx = x + (y * cloned.Width * 3) + 54;

                                //var pixel = (int)Math.Round(.299 * buffer[idx] + .587 * buffer[idx + 1] + .114 * buffer[idx + 2]);
                                var pixel = buffer[idx];
                                segTotal++;


                                //                  buffer[idx] = (byte)pixel;
                                segOn += (pixel > 40) ? 1 : 0;
                            }
                            bldr.AppendLine(";");
                        }
                    }

                    var isOn = (byte)((segOn / (float)segTotal) > 0.20 ? 1 : 0);
                    return isOn;
                }
            }

            public override string ToString()
            {
                return $"{_name}\t x={_left}, y={_top} - w={_right - _left}, h={_bottom - _top}";
            }
        }

        class Digit
        {
            readonly byte _mask;
            readonly string _digit;

            public Digit(byte topRight,
                byte bottomRight,
                byte bottom,
                byte bottomLeft,
                byte topLeft,
                byte top,
                byte center,
                String digit)
            {
                _mask = (byte)(topRight |
                        (bottomRight << 1) |
                        (bottom << 2) |
                        (bottomLeft << 3) |
                        (topLeft << 4) |
                        (top << 5) |
                        (center << 6)
                        );

                _digit = digit;
            }

            public byte Mask => _mask;


            public override string ToString()
            {
                return _digit;
            }
        }


        static String ProcessImage(Image fullImage, int left, int top, int digitWidth, int digitHeight)
        {
            var digits = new List<Digit> {
                new Digit(1, 1,  1,  1,  1,  1,  0, "0"),
                new Digit(1, 1,  0, 0, 0, 0, 0,"1"),
                new Digit(1, 0, 1,  1,  0, 1,  1, "2"),
                new Digit(1,  1,  1,  0, 0, 1,  1, "3"),
                new Digit(1,  1,  0, 0, 1,  0, 1, "4"),
                new Digit(0, 1,  1,  0, 1,  1,  1, "5"),
                new Digit(0, 1,  1,  1,  1,  1,  1, "6"),
                new Digit(1,  1,  0, 0, 0, 1,  0, "7"),
                new Digit(1,  1,  1,  1,  1,  1,  1, "8"),
                new Digit(1,  1,  1,  0, 1,  1,  1 ,"9"),
                new Digit(0, 0, 0, 0, 0, 1,  1, "-")
            };

            Console.WriteLine($"The image size: {fullImage.Width}x{fullImage.Height} - {left} {top} {digitWidth} {digitHeight}");

            using (var image = fullImage.Clone(ss => ss.Crop(new Rectangle(left, top, digitWidth, digitHeight))))
            {
                var arc_tan_theta = 6;
                var w = image.Width;
                var h = image.Height;
                var center_y = h / 2;
                var quater_y_1 = h / 4;
                var quater_y_3 = quater_y_1 * 3;
                var center_x = w / 2;
                var line_width = 5;

                var width = (Math.Max((int)(w * 0.15), 1) + Math.Max((int)(h * 0.15), 1)) / 2;
                var small_delta = (int)(h / arc_tan_theta) / 4;

                var segments = new List<Segement>();
                segments.Add(new Segement("Top Right", w - 2 * width, quater_y_1 - line_width, w, quater_y_1 + line_width));
                segments.Add(new Segement("Bottom Right", w - 2 * width, quater_y_3 - line_width, w, quater_y_3 + line_width));

                segments.Add(new Segement("Bottom", center_x - line_width - small_delta, h - 2 * width, center_x - small_delta + line_width, h));

                segments.Add(new Segement("Bottom Left", 0, quater_y_3 - line_width, 2 * width, quater_y_3 + line_width));
                segments.Add(new Segement("Top Left", 0, quater_y_1 - line_width, 2 * width, quater_y_1 + line_width));
                segments.Add(new Segement("Top   ", center_x - line_width, 0, center_x + line_width, 2 * width));
                segments.Add(new Segement("Center", center_x - line_width, center_y - (line_width * 2), center_x + line_width, center_y + (line_width * 2)));

                image.Mutate(x => x.Grayscale());
                var isEnabled = new List<bool>();
                byte digitMask = 0;
                for (int idx = 0; idx < 7; ++idx)
                {
                    digitMask |= (byte)(segments[idx].IsEnabled(image) << idx);
                }

                var foundDigit = digits.Where(dig => dig.Mask == digitMask).FirstOrDefault();
                return foundDigit != null ? foundDigit.ToString() : String.Empty;
            }
        }

        public static InvokeResult<List<SevenSegementParseResult>> Parse(DeviceMessageDefinition messageDefinition)
        {
            var  imageBytes = Convert.FromBase64String(messageDefinition.B64Image.Substring(messageDefinition.B64Image.IndexOf(',') + 1));
            return Parse(messageDefinition, imageBytes);
        }

        public static InvokeResult<List<SevenSegementParseResult>> Parse(DeviceMessageDefinition messageDefinition, byte[] imageBytes)
        {
            var msgValues = new List<SevenSegementParseResult>();

            var image = Image.Load(imageBytes);

            foreach(var field in messageDefinition.Fields)
            {
                var bldr = new StringBuilder();
                foreach(var segement in field.Segments)
                {
                    bldr.Append(ProcessImage(image, segement.Left, segement.Top, segement.Width, segement.Height));
                }

                msgValues.Add(new SevenSegementParseResult()
                {
                    MessageFieldId = field.Id,
                    MessageFieldKey = field.Key,
                    Value = bldr.ToString()
                });
            }

            return InvokeResult<List<SevenSegementParseResult>>.Create(msgValues);
        }
    }
}
