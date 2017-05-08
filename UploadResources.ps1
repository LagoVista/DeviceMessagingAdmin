Param([string]$storageKey)

function Add-Entity() {
    [CmdletBinding()]
    param(
       $table,
       [String]$partitionKey,
       [String]$rowKey,
       [String]$text,
       [String]$status
    )

  $entity = New-Object -TypeName Microsoft.WindowsAzure.Storage.Table.DynamicTableEntity -ArgumentList $partitionKey, $rowKey
  $entity.Properties.Add("Text", $text)
  $entity.Properties.Add("Status", $status)

  $result = $table.CloudTable.Execute([Microsoft.WindowsAzure.Storage.Table.TableOperation]::InsertOrReplace($entity))
}

$StorageAccountName = "nuviotresources"
#$StorageAccountKey = Get-AzureStorageKey -StorageAccountName $StorageAccountName
$Ctx = New-AzureStorageContext $StorageAccountName -StorageAccountKey $storageKey
$TableName = "allresources"

Write-Output $ctx

$scriptPath = Split-Path $MyInvocation.MyCommand.Path
Set-Location $scriptPath

 $SubscriptionName = "Primary"

 # Give a name to your new storage account. It must be lowercase!
 $StorageAccountName = "nuviotresources"

 $table = Get-AzureStorageTable –Name $TableName -Context $Ctx -ErrorAction Ignore

#Create a new table if it does not exist.
if ($table -eq $null)
{
   $table = New-AzureStorageTable –Name $TableName -Context $Ctx
}


$children = gci ./ -recurse *.resx 
foreach( $child in $children){

    $nuspecFile = gi $child.fullName
    [xml] $content = Get-Content $nuspecFile
     foreach($item in $content.root.data){
     Add-Entity -Table $table -PartitionKey $child.name -RowKey $item.name -Text $item.value -Status new
    #    Write-Output $child.Name $item.name  " " $item.value
     }

}