using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryWalmart.Model
{
    internal class Account
    {
        //Atributos
        private int idAccount;
        private int idUser;
        private string userName;
        private string password;
        private Boolean statusAccount;

        //Constructores
        public Account() { }
        public Account(int idAccount, int idUser, string userName, string password, Boolean statusAccount)
        {
            this.idAccount = idAccount;
            this.idUser = idUser;
            this.userName = userName;
            this.password = password;
            this.statusAccount = statusAccount;
        }

        //Getters y Setters
        public int GetIdAccount() { return this.idAccount; }
        public void SetIdAccount(int idAccount) { this.idAccount = idAccount; }
        //--------
        public int GetIdUser() {  return this.idUser; }
        public void SetIdUser(int idUser) {  this.idUser = idUser; }
        //--------
        public string GetUserName() { return this.userName;}
        public void SetUserName(string userName) { this.userName = userName;}
        //--------
        public string GetPassword() { return password;}
        public void SetPassword(string password) { this.password = password;}
        //--------
        public Boolean GetStatusAccount() {  return this.statusAccount; }
        public void SetStatusAccount(Boolean statusAccount) { this.statusAccount = statusAccount; }
    }
}
