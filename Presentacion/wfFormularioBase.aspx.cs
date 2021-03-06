﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Presentacion
{
    public partial class wfFormularioBase : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btn_Recuperar_Click(object sender, EventArgs e)
        {

            try
            {
                Negocio.NegocioClientes dc = new Negocio.NegocioClientes();
                Entidad.Clientes clientes = dc.RecuperarCliente(int.Parse(txt_Id.Text));
                if (clientes != null)
                {

                    txt_Nombres.Text = clientes.Nombre;

                }

                else

                {
                    lblMessage.Text = "No existe el cliente con este id.";
                }


            }
            catch (Exception err)
            {

                throw err;
            }

        }

        protected void btn_Confirmar_Click(object sender, EventArgs e)
        {
            try
            {
                Entidad.Clientes customer = new Entidad.Clientes();
                customer.Id = int.Parse(txt_Id.Text);
                customer.Nombre = txt_Nombres.Text.Trim();
                customer.FechaProceso = DateTime.Now;
                customer.UsuarioProceso = 1;
                customer.Estado = 2;
                Negocio.NegocioClientes dc = new Negocio.NegocioClientes();
                dc.ActualizarClientes(customer);
                lblMessage.Text = "El usuario fue actualizado Exitosamente";
            }
            catch (Exception err)
            {

                throw err;
            }
            
        }
                

    }   
}