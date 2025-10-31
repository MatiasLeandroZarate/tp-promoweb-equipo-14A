using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Voucher
    {
        private string voucher;
        public string CodigoVoucher { get; set; }
        //{
        //    get { return voucher; }
        //    set
        //    {
        //        if (voucher != "" || voucher != null)
        //        {
        //            voucher = value;
        //        }
        //        else
        //        {
        //            throw new Exception("Ingrese Voucher");
        //        }
        //    }
        //}
        public int IdCliente { get; set; }
        public DateTime FechaCanje { get; set; }
        public int IdArticulo { get; set; }
    }
}
