# Configure the Azure provider

provider "azurerm" {
  subscription_id = var.subscription_id
  # tenant_id = var.tenant_id
  # client_id = var.client_id
  # client_secret = var.client_secret
  # skip_provider_registration = "true"
  features {}
}

resource "azurerm_resource_group" "adhocrg" {
  name     = var.azurerm_resource_group_name
  location = var.location

  tags = {
    Environment = "Adhoc Environment"
    Team = "Logic Console"
  }
}

resource "azurerm_storage_account" "adhocenvstorageaccount" {
  name = var.azurerm_storage_account_name
  resource_group_name = azurerm_resource_group.adhocrg.name
  location = azurerm_resource_group.adhocrg.location
  account_tier = var.account_tier
  account_kind = var.accout_kind
  account_replication_type =var.account_replication_type

  tags = {
    Environment = "adhoc"
  }
   
  static_website {
    index_document = "index.html"
    error_404_document = "404.html"
  }

}

output "static-web-url" {
  value = azurerm_storage_account.adhocenvstorageaccount.primary_web_endpoint
}