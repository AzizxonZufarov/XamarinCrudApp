using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace XamarinForms
{
    public class DB
    {
        private readonly SQLiteConnection conn;

        public DB(string path)
        {
            conn = new SQLiteConnection(path);
            conn.CreateTable<Item>();
        }

        public List<Item> GetItems()
        {
            return conn.Table<Item>().ToList();
        }

        public int SaveItem(Item item)
        {
            return conn.Insert(item);
        }

        public int DeleteItem(int id)
        {
            return conn.Delete<Item>(id);
        }

        public int UpdateItem(Item item)
        {
            return conn.Update(item);
        }

        /*public object GetItemById(int id)
        {
            return conn.Get<Item>(id);
        }*/

    }
}