﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BLL;
using Newtonsoft.Json;
using ProyectoV.Models;

namespace ProyectoV.Controllers
{
    public class ComprasController : ApiController
    {
        // GET: api/Compras
        string mensaje_error;
        int numero_error;
        public List<Compras> Get()
        {
            List<Compras> item_carlist = new Compras().cargar_compras(ref mensaje_error, ref numero_error, Compras.GlobalValueUSER);
            return item_carlist;
        }

        // GET: api/Compras/5
        public Compras Get(int id)
        {
            List<Compras> item_carlist = new Compras().cargar_compras(ref mensaje_error, ref numero_error, Compras.GlobalValueUSER);
            crypting c = new crypting();
            Compras x = item_carlist.ElementAt(id);
            Compras spes = new Compras();
            spes.Codigo_Compras = x.Codigo_Compras;
            spes.Cod_User_FK = c.decrypt(x.Cod_User_FK);
            spes.Codigo_Vuelo_FK = x.Codigo_Vuelo_FK;
            spes.Cantidad = c.decrypt(x.Cantidad);
            spes.Total = x.Total;
            spes.DateBuy = c.decrypt(x.DateBuy);
            return spes;
        }

        // POST: api/Compras
        public void Post([FromBody] Compras value)
        {
            Compras.GlobalValueUSER = value.Cod_User_FK;
        }
    }
}
