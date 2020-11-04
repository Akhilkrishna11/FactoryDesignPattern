variable location {
    type = string
    description = "Resource Group location"
    default="westus2"
}

variable subscription_id {
    type = string
    description = "Azure Subscription Id"
    default = "7940b735-ab20-47f7-9edc-c24ed0336473"
}

variable tenant_id {
    type = string
    description = "Tenent Id"
    default = "1aaaea9d-df3e-4ce7-a55d-43de56e79442"
}

variable client_id {
    type = string
    description = "Client Id"
    default = "b7441ce8-01f1-4d90-ba25-f63bab554f69"
}

variable client_secret {
    type = string
    description = "Client Secret"
    default ="o~O~mQSN1.Js4eZ0J7~x_QKDf3Qe41d6Di"
}

variable account_tier {
    type = string
    description = "Storage account tier (Standard Premium)"
    default = "Standard"
}

variable account_replication_type {
    type = string
    description = "Storage account tier (LRS/ZRS/GRS/RA-GRS/GZRS/RA-GZRS)"
    default = "LRS"
}

variable azurerm_resource_group_name {
    type = string
    description = "Resource Group Name"
    default = "adhocenvrg"
}

variable azurerm_storage_account_name {
    type = string
    description = "Azure Storage account name"
    default ="adhocenvstorageaccount"
}

variable accout_kind {
    type = string
    description = "Resource Group Name"
    default = "StorageV2"
}