using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace TareaSemSieteRickyBlacio
{
    public interface DataBase
    {
        SQLiteAsyncConnection GetConnection();
    }
}
