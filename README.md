# email-to-UPN-converter-for-MS365-power-automate
This Azure Function converts a single e-mailadres that is external to your tenant to a UPN. Useful for adding existing guests to a new team in Microsoft Power Automate/Flow.

## Setup

### Azure function

1. Create an Azure app
2. Create an Azure function called 'email2upn'in the Azure app based on the HTTP trigger template
3. Replace the code in the run.csx file with the code from that file in this repository
4. Replace the word 'blabla' in the code with the name of your organisation's MS365 tenant
5. Click on get function url

### Power automate custom connector (optional)

Optionally you can use the function through a custom connector in Power Automate. 

1. In Power Automate, go to Data/Custom connectors and click new
2. Switch on the Swagger editor
3. Copy paste the configuration code from the Power_Automate_Custom_connector.json file in this repository to your custom connector
4. Change the url to the url copied from the Azure function
5. Change the domain form 'blabla' to the email domain of your organisation

## Usage
You can set a parameter called domain and email in a GET query like so 
 `https://blabla.azurewebsites.net/api/email2UPN?domain=blabla.com&email=henryford@gmail.com`

 Or POST JSON with the csv parameter like so:
 
 `{
 "email": "henryford@gmail.com",
 "domain": "blabla.com"
}`

In both cases the function will return the UPN as the body, like so:

`henryford_gmail.com#ext#@blabla.onmicrosoft.com`
