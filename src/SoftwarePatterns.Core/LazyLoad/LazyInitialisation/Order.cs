using System;
using System.Runtime.Remoting;

namespace SoftwarePatterns.Core.LazyLoad.LazyInitialisation
{
	/// <summary>
	/// An example of bad simple lazy initialisation class
	/// </summary>
	public class OrderBad
	{
		private Customer _customer;

		public Customer Customer
		{
			get
			{
				//probably returned from storage
				return _customer ?? (_customer = new Customer());//not thread safe
			}
			set { _customer = value; }
		}

		public string Print()
		{
			return string.Format("Customer Name: {0}", _customer.Name);//nuff ref error
		}
	}

	/// <summary>
	/// An example of  better lazy initialisation  class
	/// </summary>
	public class OrderGood
	{
		private Customer _customer;

		public Customer Customer
		{
			get
			{
				//probably returned from storage
				return _customer ?? (_customer = new Customer());//not thread safe
			}
			set { _customer = value; }
		}

		public string Print()
		{
			return string.Format("Customer Name: {0}", Customer.Name);
		}
	}

	/// <summary>
	/// Order loading the customer using the lazy of T type in .net 4
	/// </summary>
	public class OrderLazy
	{
		private readonly Lazy<Customer> _customerInitializer;

		public OrderLazy()
		{
			//thread safe by default can overload constructor to turn off for performance improvements
			_customerInitializer = new Lazy<Customer>(() => new Customer());
		}

		public Customer Customer
		{
			get
			{
				//probably returned from storage
				return _customerInitializer.Value;
			}
		}

		public string Print()
		{
			return string.Format("Customer Name: {0}", Customer.Name);
		}
	}
}