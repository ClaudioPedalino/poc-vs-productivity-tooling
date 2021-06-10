using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace poc_vs_tooling.Entities.Test
{
    // [CP] Exraer en interfaz, extraer en clase base
    public class Test // : BaseClass , ITest
    {

        public uint MyProperty1 { get; set; }  // [CP] Pullear a clase base
        public string MyProperty2 { get; set; }
        public string MyProperty3 { get; set; }


        /// snippets 'prop' 'ctor'


        /// [CP] Pullear a interfaz
        public decimal Sum(decimal? num1, decimal? num2)
        {
            decimal result = 0;

            if (!num1.HasValue && !num2.HasValue)
                return result;

            // [CP] coalesce expression
            result += num1.HasValue ? num1.Value : 0;
            result += num2.HasValue ? num2.Value : 0;

            return result;

        }


        public Task<string> GetPaymentMethod(int paymentMethodId)
        {
            var type = string.Empty;

            //[CP] Switch expresion // pattern matching
            switch (paymentMethodId)
            {
                case (int)PaymentMethods.Cash:
                    type = PaymentMethods.Cash.ToString();
                    break;
                case (int)PaymentMethods.CreditCadrd:
                    type = PaymentMethods.CreditCadrd.ToString();
                    break;
                case (int)PaymentMethods.DebitCard:
                    type = PaymentMethods.DebitCard.ToString();
                    break;
                case (int)PaymentMethods.Crypto:
                    type = PaymentMethods.Crypto.ToString();
                    break;
                case (int)PaymentMethods.Check:
                    type = PaymentMethods.Check.ToString();
                    break;
                default:
                    type = default;
                    break;
            }

            #region resultado
            //type = paymentMethodId switch
            //{
            //    (int)PaymentMethods.Cash        => PaymentMethods.Cash.ToString(),
            //    (int)PaymentMethods.CreditCadrd => PaymentMethods.CreditCadrd.ToString(),
            //    (int)PaymentMethods.DebitCard   => PaymentMethods.DebitCard.ToString(),
            //    (int)PaymentMethods.Crypyo      => PaymentMethods.Crypyo.ToString(),
            //    (int)PaymentMethods.Check       => PaymentMethods.Check.ToString(),
            //    _ => default,
            //};
            #endregion

            return Task.FromResult(type);
        }


        /// [CP] Wrap params
        /// [CP] Modificar firma
        public void WrapManyParameters(int param1, int param2, int param3, decimal param4, List<int> param5, List<string> param6)
        {
            Console.WriteLine("WrapManyParameters");
        }

    }

    public enum PaymentMethods
    {
        Cash = 1,
        CreditCadrd = 2,
        DebitCard = 3,
        Crypto = 4,
        Check = 5
    }





    public class AnotherTest
    {
        public void InstanceTest()
        {
            var test = new Test();

            // [CP] Añadir parametros nombrados para evitar misspelling
            test.WrapManyParameters(1, 2, 3, 2M, new List<int> { 1, 2, 3 }, new List<string>() { "Hola", "Tarola" });
        }

        public void NamedParameters()
        {
            // Cuál es Abril cuál Junio?
            DateTime date1 = new DateTime(2021, 4, 6, 7, 30, 10, 200);
            DateTime date2 = new DateTime(2021, 6, 4, 7, 30, 10, 200);

            #region [CP] parametros nombrados
            DateTime date3 = new DateTime(year: 2021, month: 6, day: 4, hour: 7, minute: 30, second: 10, millisecond: 200);
            DateTime date4 = new DateTime(2021, 6, 4, 7, 30, 10, 200); // encender inline-parameters

            #endregion
        }

        public void VerifyAnalazyer()
        {
            int numberOne = 1;

            //if (numberOne == null)
            //{
            //    Console.WriteLine("Do something");
            //}
        }
    }
}
