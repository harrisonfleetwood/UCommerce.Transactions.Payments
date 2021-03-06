﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using NUnit.Framework;
using UCommerce.Transactions.Payments.GlobalCollect;

namespace UCommerce.Transactions.Payments.Test.GlobalCollect
{
	[TestFixture]
	public class ModifiedXmlDocumentReading
	{
		[Test]
		public void ReadGetOrderStatusResponse()
		{
			// Arrange

			// Act
			var document = new ModifiedXmlDocument(GetOrderStatusResponseText);

			// Assert
			var action = document.GetStringFromXml("XML/REQUEST/ACTION");
			Assert.AreEqual("GET_ORDERSTATUS", action);

			var ipaddress = document.GetStringFromXml("XML/REQUEST/META/IPADDRESS");
			Assert.AreEqual("123.123.123.123", ipaddress);
		}

		#region Test data
		private const string GetOrderStatusResponseText = @"<XML>
<REQUEST>
<ACTION>GET_ORDERSTATUS</ACTION>
<META>
<MERCHANTID>1</MERCHANTID>
<IPADDRESS>123.123.123.123</IPADDRESS>
<VERSION>2.0</VERSION>
<REQUESTIPADDRESS>123.123.123.123</REQUESTIPADDRESS>
</META>
<PARAMS>
<ORDER>
<ORDERID>9998890004</ORDERID>
</ORDER>
</PARAMS>
<RESPONSE>
<RESULT>OK</RESULT>
<META>
<REQUESTID>245</REQUESTID>
<RESPONSEDATETIME>20100419133351</RESPONSEDATETIME>
</META>
<STATUS>
<PAYMENTMETHODID>1</PAYMENTMETHODID>
<STATUSID>800</STATUSID>
<CURRENCYCODE>EUR</CURRENCYCODE>
<FRAUDRESULT>N</FRAUDRESULT>
<EFFORTID>1</EFFORTID>
<CREDITCARDNUMBER>************7977</CREDITCARDNUMBER>
<AUTHORISATIONCODE>654321</AUTHORISATIONCODE>
<PAYMENTREFERENCE>900100000010</PAYMENTREFERENCE>
<ATTEMPTID>2</ATTEMPTID>
<MERCHANTID>1</MERCHANTID>
<AMOUNT>2345</AMOUNT>
<STATUSDATE>20100419132926</STATUSDATE>
<PAYMENTPRODUCTID>1</PAYMENTPRODUCTID>
<CVVRESULT>0</CVVRESULT>
<ORDERID>9998890004</ORDERID>
<EXPIRYDATE>1210</EXPIRYDATE>
</STATUS>
</RESPONSE>
</REQUEST>
</XML>";
		#endregion Test data
	}
}
