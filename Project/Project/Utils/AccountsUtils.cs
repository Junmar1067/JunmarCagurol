using Project.Entity;
using Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project.Utils
{
    public class AccountsUtils
    {

        public static void Save(Accounts acc)
        {
            using (var db = new DatabaseEntities1())
            {
                var account = db.Accounts.FirstOrDefault(x => x.AccountId == acc.Id);
                if (account != null)
                {
                    account.Username = acc.Username;
                    account.Password = acc.Password;
                    account.Name = acc.Name;
                    account.Address = acc.Address;
                    account.Age = acc.Age;
                }
                else
                {
                    db.Accounts.Add(new Account { Username = acc.Username, Password = acc.Password, Name = acc.Name, Address = acc.Address, Age = acc.Age });
                }
                db.SaveChanges();
            }
        }

        public static void DeleteConfirm(int id)
        {
            using (var db = new DatabaseEntities1())
            {
                var selected = db.Accounts.FirstOrDefault(x => x.AccountId == id);
                if (selected != null)
                {
                    db.Accounts.Remove(selected);
                    db.SaveChanges();
                }
            }
        }

        public static List<Accounts> GetAccounts(int id)
        {
            using (var db = new DatabaseEntities1())
            {

                if (id != 0)
                {
                    var a = db.Accounts.Where(i => i.AccountId == id);
                    return a.Select(b => new Accounts { Id = b.AccountId, Username = b.Username, Password = b.Password, Name = b.Name, Address = b.Address, Age = b.Age }).ToList();
                }
                else
                {
                    return db.Accounts.Select(b => new Accounts { Id = b.AccountId, Username = b.Username, Password = b.Password, Name = b.Name, Address = b.Address, Age = b.Age }).ToList();
                }
            }
        }
    }
}