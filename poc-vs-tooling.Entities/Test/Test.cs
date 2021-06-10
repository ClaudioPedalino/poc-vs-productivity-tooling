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

			//[CP] Switch pattern matching
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
				case (int)PaymentMethods.Crypyo:
					type = PaymentMethods.Crypyo.ToString();
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
			//    (int)PaymentMethods.Cash => PaymentMethods.Cash.ToString(),
			//    (int)PaymentMethods.CreditCadrd => PaymentMethods.CreditCadrd.ToString(),
			//    (int)PaymentMethods.DebitCard => PaymentMethods.DebitCard.ToString(),
			//    (int)PaymentMethods.Crypyo => PaymentMethods.Crypyo.ToString(),
			//    (int)PaymentMethods.Check => PaymentMethods.Check.ToString(),
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
		Crypyo = 4,
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
	}
}
