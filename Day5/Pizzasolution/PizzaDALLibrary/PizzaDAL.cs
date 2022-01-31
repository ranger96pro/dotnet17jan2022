using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using PizzaModelsLibrary;

namespace PizzaDALLibrary
{
    public class PizzaDAL
    {
        SqlConnection conn;
        public PizzaDAL()
        {
            conn = MyConnection.GetConnection();
        }
        public ICollection<Pizza> GetAllPizzas()
        {
            List<Pizza> pizzas = new List<Pizza>();
            DataSet ds = new DataSet();
            SqlDataAdapter adapter = new SqlDataAdapter("proc_GetAllPizzas", conn);
            adapter.SelectCommand.CommandType = CommandType.StoredProcedure;

            adapter.Fill(ds);
            Pizza pizza;
            if (ds.Tables[0].Rows.Count == 0)
            {
                throw new NoPizzaException();
            }
            foreach (DataRow item in ds.Tables[0].Rows)
            {
                pizza = new Pizza();
                pizza.Id = Convert.ToInt32(item[0]);
                pizza.Name = item[1].ToString();
                pizza.IsVeg = Convert.ToBoolean(item[2]);
                pizza.Price = float.Parse(item[3].ToString());
                pizzas.Add(pizza);
            }
            return pizzas;

        }
    }
}
