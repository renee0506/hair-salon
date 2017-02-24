using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace HairSalon
{
  public class Stylist
  {
    private int _id;
    private string _name;
    private int _age;
    private string _bio;

    public Stylist(string Name, int Age, string Bio, int Id = 0)
    {
      _id = Id;
      _name = Name;
      _age = Age;
      _bio = Bio;
    }

    public int GetId()
    {
      return _id;
    }

    public string GetName()
    {
      return _name;
    }

    public int GetAge()
    {
      return _age;
    }

    public string GetBio()
    {
      return _bio;
    }

    public static void DeleteAll()
    {
      SqlConnection conn = DB.Connection();
      conn.Open();

      SqlCommand cmd = new SqlCommand("DELETE FROM stylists;", conn);
      cmd.ExecuteNonQuery();
      conn.Close();
    }

    public override bool Equals(System.Object otherStylist)
    {
      if (!(otherStylist is Stylist))
      {
        return false;
      }
      else
      {
        Stylist newStylist = (Stylist) otherStylist;
        bool idEquality = (this.GetId() == newStylist.GetId());
        bool nameEquality = (this.GetName() == newStylist.GetName());
        bool ageEquality = (this.GetAge() == newStylist.GetAge());
        bool bioEquality = (this.GetBio() == newStylist.GetBio());

        return (idEquality && nameEquality && ageEquality && bioEquality);
      }
    }

    public static List<Stylist> GetAll()
    {
      List<Stylist> allStylists = new List<Stylist>{};
      SqlConnection conn = DB.Connection();
      conn.Open();

      SqlCommand cmd = new SqlCommand("SELECT * FROM stylists;", conn);
      SqlDataReader rdr = cmd.ExecuteReader();

      while(rdr.Read())
      {
        int id = rdr.GetInt32(0);
        string name = rdr.GetString(1);
        int age = rdr.GetInt32(2);
        string bio = rdr.GetString(3);

        Stylist newStylist = new Stylist(name, age, bio, id);
        allStylists.Add(newStylist);
      }

      if (rdr != null)
      {
        rdr.Close();
      }
      if (conn != null)
      {
        conn.Close();
      }
      return allStylists;
    }

    public void Save()
    {
      SqlConnection conn = DB.Connection();
      conn.Open();

      SqlCommand cmd = new SqlCommand("INSERT INTO stylists (name, age, bio) OUTPUT INSERTED.id VALUES (@Name, @Age, @Bio);", conn);

      SqlParameter stylistNameParameter = new SqlParameter("@Name", this.GetName());
      SqlParameter stylistAgeParameter = new SqlParameter("@Age", this.GetAge());
      SqlParameter stylistBioParameter = new SqlParameter("@Bio", this.GetBio());


      cmd.Parameters.Add(stylistNameParameter);
      cmd.Parameters.Add(stylistAgeParameter);
      cmd.Parameters.Add(stylistBioParameter);
      SqlDataReader rdr = cmd.ExecuteReader();

      while(rdr.Read())
      {
        this._id = rdr.GetInt32(0);
      }

      if (rdr != null)
      {
        rdr.Close();
      }
      if (conn != null)
      {
        conn.Close();
      }
    }

    public static Stylist Find(int id)
    {
      SqlConnection conn = DB.Connection();
      conn.Open();

      SqlCommand cmd = new SqlCommand("SELECT * FROM stylists WHERE id = @Id;", conn);

      SqlParameter idParamter= new SqlParameter("@Id", id);
      cmd.Parameters.Add(idParamter);

      SqlDataReader rdr = cmd.ExecuteReader();

      int foundStylistId = 0;
      string foundStylistName = null;
      int foundStylistAge = 0;
      string foundStylistBio = null;

      while(rdr.Read())
      {
        foundStylistId = rdr.GetInt32(0);
        foundStylistName = rdr.GetString(1);
        foundStylistAge = rdr.GetInt32(2);
        foundStylistBio = rdr.GetString(3);
      }

      Stylist foundStylist = new Stylist(foundStylistName, foundStylistAge, foundStylistBio, foundStylistId);

      if (rdr != null)
      {
        rdr.Close();
      }
      if (conn != null)
      {
        conn.Close();
      }

      return foundStylist;
    }

  }
}
