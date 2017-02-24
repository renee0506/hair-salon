using Xunit;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace HairSalon
{
  public class StylistTest : IDisposable
  {
    public StylistTest()
    {
      DBConfiguration.ConnectionString = "Data Source=(localdb)\\mssqllocaldb;Initial Catalog=hair_salon_test;Integrated Security=SSPI;";
    }

    public void Dispose()
    {
      Stylist.DeleteAll();
    }

    [Fact]
    public void Test_StylistTableEmptyAtFirst()
    {
      int result = Stylist.GetAll().Count;

      Assert.Equal(0, result);
    }

    [Fact]
    public void Test_EqualOverrideTrueIfStylistNameAgeBioSame()
    {
      Stylist firstStylist = new Stylist("Joe", 24, "5 years in the Industry");
      Stylist secondStylist = new Stylist("Joe", 24, "5 years in the Industry");

      Assert.Equal(firstStylist, secondStylist);
    }
  }
}
