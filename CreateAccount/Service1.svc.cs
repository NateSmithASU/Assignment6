using CreateAccount.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;

namespace CreateAccount
{
    public class Service1 : IService1
    {
        public string CreateAccount(string username, string password)
        {
            Register reg = new Register();

            string path = HttpRuntime.AppDomainAppPath + "\\accounts.json"; // File path to accounts.json

            var initialJson = File.ReadAllText(path); // Read json file first to get list of user accounts
            reg = JsonConvert.DeserializeObject<Register>(initialJson); //Deserializes json file into Register object in order to be iterated through
            bool userExists = false;
            for(int i =0; i < reg.accounts.Count; i++) //loop through all the accounts  
            {
                if (username.Equals(reg.accounts[i].username)) //check if user already exists in file
                {
                    userExists = true;
                    break;
                }
            }

            if (!userExists)
            {
                //Password must be 8 to 32 characters, with at least 1 number and either 1 of the following characters ! @ # $ _ - % or 1 uppercase character
                if (Regex.IsMatch(password, @"^(?=.*\d)(((?=.*[A-Z])(?=.*[a-z]))|((?=.*[!@#$_\-%]))|((?=.*[a-z])(?=.*[!@#$_\-%])))[A-Za-z\d!@#$_\-%]{8,32}$"))
                {
                    EncryptionService.ServiceClient encryption = new EncryptionService.ServiceClient(); //initialized encryption services
                    var encryptedPassword = encryption.Encrypt(password); //encrypt password and store in variable
                    Account acc = new Account(); //create the account object to store users credentials
                    acc.username = username;
                    acc.password = encryptedPassword;
                    reg.accounts.Add(acc);
                   
                    var response = JsonConvert.SerializeObject(reg); //Serializes the object back into readible json
                    File.WriteAllText(path, response); //Writes the account list to the accounts.json file
                    return "Account has been created successfully.";
                }
                else
                {
                    return "Invalid Password";
                }
            }
            else
            {
                return "username already exist. Please choose a different one.";
            }
            
        }
    }
}
