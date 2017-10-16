using System;
namespace WeStock.Entities
{
    public class DetalleArticulo
    {

        public string Codigo
        {
            get;
            set;
        }

        public int Medida
        {
            get;
            set;
        }

        public int Color
        {
            get;
            set;
        }

        public string Unidad
		{
			get;
			set;
		}

        public int Deposito
        {
            get;
            set;
        }

        public DateTime? Fecha
        {
            get;
            set;
        }

        public string Comprobante
        {
            get;
            set;
        }

        public int? Ingreso
        {
            get;
            set;
        }

        public int? Egreso
        {
            get;
            set;
        }

        public int Saldo
        {
            get;
            set;
        }
    }
}

