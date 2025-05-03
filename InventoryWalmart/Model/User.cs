using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryWalmart.Model
{
    internal class User
    {
        private int id_user;
        private int id_district;
        private int id_role;
        private string first_name;
        private string last_name;
        private DateTime date_of_birth;
        private DateTime hire_date;
        private string cellphone;
        private string dui;
        private int id_department;

        public User() { }

        public User(int id_user, int id_district, int id_role, string first_name, string last_name, DateTime date_of_birth, DateTime hire_date, string cellphone, string dui, int id_department)
        {
            this.id_user = id_user;
            this.id_district = id_district;
            this.id_role = id_role;
            this.first_name = first_name;
            this.last_name = last_name;
            this.date_of_birth = date_of_birth;
            this.hire_date = hire_date;
            this.cellphone = cellphone;
            this.dui = dui;
            this.id_department = id_department;
        }

        //Getters y Setters

        public int GetIdUser() { return this.id_user; }
        public void SetIdUser(int id_user) { this.id_user = id_user; }
        //------
        public int GetIdDistrict() { return this.id_district; }
        public void SetIdDistrict(int id_district) { this.id_district = id_district; }
        //------
        public int GetIdRole() {  return this.id_role; }
        public void SetIdRole(int id_role) { this.id_role = id_role; }
        //-------
        public string GetFirst_name() {  return this.first_name; }
        public void SetFirst_name(string first_name) { this.first_name = first_name; }
        //-------
        public string GetLast_name() { return this.last_name; }
        public void SetLast_name(string last_name) { this.last_name = last_name;}
        //-------
        public DateTime GetDate_of_birth() {  return this.date_of_birth; }
        public void SetDate_of_birth(DateTime date_of_birth) { this.date_of_birth = date_of_birth; }
        //------
        public DateTime GetHire_date() { return this.hire_date; }
        public void SetHire_date(DateTime hire_date) { this.hire_date = hire_date; }
        //------
        public string GetCellphone() { return this.cellphone; }
        public void SetCellphone(string cellphone) { this.cellphone = cellphone; }
        //------
        public string GetDui() { return this.dui; }
        public void SetDui(string dui) { this.dui = dui; }
        //------
        public int GetIdDepartment() { return this.id_department; }
        public void SetIdDepartment(int id_department) { this.id_department = id_department; }

    }
}
