// Copyright (C) 2004-2005 MySQL AB
//
// This program is free software; you can redistribute it and/or modify
// it under the terms of the GNU General Public License version 2 as published by
// the Free Software Foundation
//
// There are special exceptions to the terms and conditions of the GPL 
// as it is applied to this software. View the full text of the 
// exception in file EXCEPTIONS in the directory of this software 
// distribution.
//
// This program is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU General Public License for more details.
//
// You should have received a copy of the GNU General Public License
// along with this program; if not, write to the Free Software
// Foundation, Inc., 59 Temple Place, Suite 330, Boston, MA  02111-1307  USA 

using System;
using System.Data;
using MySql.Data.MySqlClient;
using NUnit.Framework;

namespace MySql.Data.MySqlClient.Tests
{
	[TestFixture()]
	public class CommandTests : BaseTest
	{

		[TestFixtureSetUp]
		public void TestFixtureSetUp()
		{
			Open();
			execSQL("DROP TABLE IF EXISTS Test");
			execSQL("CREATE TABLE Test (id int NOT NULL, name VARCHAR(100))");
		}

		[TestFixtureTearDown]
		public void TestFixtureTearDown() 
		{
			Close();
		}

		[Test()]
		public void InsertTest()
		{
			try 
			{
				// do the insert
				MySqlCommand cmd = new MySqlCommand("INSERT INTO Test (id,name) VALUES(10,'Test')", conn);
				int cnt = cmd.ExecuteNonQuery();
				Assert.AreEqual( 1, cnt, "Insert Count" );

				// make sure we get the right value back out
				cmd.CommandText = "SELECT name FROM Test WHERE id=10";
				string name = (string)cmd.ExecuteScalar();
				Assert.AreEqual( "Test", name, "Insert result" );

				// now do the insert with parameters
				cmd.CommandText = "INSERT INTO Test (id,name) VALUES(?id, ?name)";
				cmd.Parameters.Add( new MySqlParameter("?id", 11));
				cmd.Parameters.Add( new MySqlParameter("?name", "Test2"));
				cnt = cmd.ExecuteNonQuery();
				Assert.AreEqual( 1, cnt, "Insert with Parameters Count" );

				// make sure we get the right value back out
				cmd.Parameters.Clear();
				cmd.CommandText = "SELECT name FROM Test WHERE id=11";
				name = (string)cmd.ExecuteScalar();
				Assert.AreEqual( "Test2", name, "Insert with parameters result" );
			}
			catch (MySqlException ex)
			{
				Assert.Fail( ex.Message );
			}
		}

		[Test()]
		public void UpdateTest()
		{
			try 
			{
				execSQL("INSERT INTO Test (id,name) VALUES(10, 'Test')");
				execSQL("INSERT INTO Test (id,name) VALUES(11, 'Test2')");

				// do the update
				MySqlCommand cmd = new MySqlCommand("UPDATE Test SET name='Test3' WHERE id=10 OR id=11", conn);
				MySqlConnection c = cmd.Connection;
				Assert.AreEqual( conn, c );
				int cnt = cmd.ExecuteNonQuery();
				Assert.AreEqual( 2, cnt );

				// make sure we get the right value back out
				cmd.CommandText = "SELECT name FROM Test WHERE id=10";
				string name = (string)cmd.ExecuteScalar();
				Assert.AreEqual( "Test3", name );
			
				cmd.CommandText = "SELECT name FROM Test WHERE id=11";
				name = (string)cmd.ExecuteScalar();
				Assert.AreEqual( "Test3", name );

				// now do the update with parameters
				cmd.CommandText = "UPDATE Test SET name=?name WHERE id=?id";
				cmd.Parameters.Add( new MySqlParameter("?id", 11));
				cmd.Parameters.Add( new MySqlParameter("?name", "Test5"));
				cnt = cmd.ExecuteNonQuery();
				Assert.AreEqual( 1, cnt, "Update with Parameters Count" );

				// make sure we get the right value back out
				cmd.Parameters.Clear();
				cmd.CommandText = "SELECT name FROM Test WHERE id=11";
				name = (string)cmd.ExecuteScalar();
				Assert.AreEqual( "Test5", name );
			}
			catch (Exception ex)
			{
				Assert.Fail( ex.Message );
			}
		}

		[Test()]
		public void DeleteTest()
		{
			try 
			{
				execSQL("INSERT INTO Test (id, name) VALUES(1, 'Test')");
				execSQL("INSERT INTO Test (id, name) VALUES(2, 'Test2')");

				// make sure we get the right value back out
				MySqlCommand cmd = new MySqlCommand("DELETE FROM Test WHERE id=1 or id=2", conn);
				int delcnt = cmd.ExecuteNonQuery();
				Assert.AreEqual( 2, delcnt );
			
				// find out how many rows we have now
				cmd.CommandText = "SELECT COUNT(*) FROM Test";
				object after_cnt = cmd.ExecuteScalar();
				Assert.AreEqual( 0, after_cnt );
			}
			catch (Exception ex)
			{
				Assert.Fail( ex.Message );
			}
		}

		[Test]
		public void CtorTest() 
		{
			MySqlTransaction txn = conn.BeginTransaction();
			MySqlCommand cmd = new MySqlCommand("SELECT * FROM Test", conn);

			MySqlCommand clone = new MySqlCommand( cmd.CommandText, (MySqlConnection)cmd.Connection, 
				(MySqlTransaction)cmd.Transaction );
			clone.Parameters.Add( "?test", 1 );
			txn.Rollback();
		}

		[Test]
		public void CloneCommand() 
		{
			IDbCommand cmd = new MySqlCommand();
			IDbCommand cmd2 = ((ICloneable)cmd).Clone() as IDbCommand;
			cmd2.ToString();
		}

		[Test]
		public void TableWithOVer100Columns()
		{
			string sql = "create table IF NOT EXISTS zvan (id int(8) primary key " + 
				"unique auto_increment, name varchar(250)) TYPE=INNODB;  ";
/*				"create table IF NOT EXISTS ljudyna (id int(8) primary key " +
				"unique auto_increment, name varchar(250), data_narod date, " +
				"id_in_zvan int(8), kandidat varchar(250), tel_rob_vn varchar(250), " +
				"tel_rob_mis varchar(250), n_kabin varchar(250), n_nak_zvan varchar(250), " +
				"d_nak_zvan date, sex tinyint(1), n_nak_pos varchar(250), " +
				"d_nak_pos date, posad_data varchar(250), visl1 varchar(250), visl2 " +
				"varchar(250), visl3 varchar(250), cpidr_f int(8), cposad_f int(8), sumis " +
				"tinyint(1), zs_s date, zs_po date, ovs_z date, ovs_po date, naiavn_zviln " +
				"tinyint(1), ovs_z1 date, ovs_po1 date, ovs_z2 date, ovs_po2 date, ovs_z3 date, " +
				"ovs_po3 date, ovs_prakt varchar(250), data_atest date, data_sp date, v_akad_z " +
				"date, z_akad_zvln tinyint(1), v_akad_period varchar(250), nauk_stup " +
				"varchar(250), vch_zvan varchar(250), n_sprav varchar(250), n_posv varchar(250), " +
				"nacional varchar(250), osvita varchar(250), osvita_zakin_sho varchar(250), " +
				"osvita_zakin_koli date, osvita_special varchar(250), osvita_kvalifikac " +
				"varchar(250), de_navchaet varchar(250), data_vstupu date, termin_navch " +
				"varchar(250), adresa varchar(250), tel_dom varchar(250), marka_avto " +
				"varchar(250), n_avto varchar(250), color_avto varchar(250), vikor_avto " +
				"varchar(250), posv_avto varchar(250), marka_zbr varchar(250), nomer_calibr_zbr " +
				"varchar(250), vid_zbr varchar(250), nomer_data_razreshen varchar(250), pasport " +
				"varchar(250), oklad1 varchar(250), prem07_2003 varchar(250), nadb07_2003 " +
				"varchar(250), osob_nom varchar(250), nadbavka_stag_max varchar(250), " +
				"nadbavka_stag_08_2003 varchar(250), nadbavka_stag_10_2003 varchar(250), " +
				"nadbavka_stag_11_2003 varchar(250), nadbavka_stag_02_2004 varchar(250), " +
				"vidp_vikoristav varchar(250), vidp_plan varchar(250), vidp_vidgil varchar(250), " +
				"vidp_nevidgil_dniv varchar(250), nadb111 varchar(250), prem_3_1 varchar(250), " +
				"nadb_4_1 varchar(250), prem_3_2 varchar(250), nadb_3_2 varchar(250), nedolos " +
				"varchar(250), sposl int(8), cposl int(8), czaoh int(8), 07_2003_oklad " +
				"varchar(250), 05_2003_oklad varchar(250), deti_jeni varchar(250), nadb_volny " +
				"varchar(250), prem_volny varchar(250), dispanser tinyint(1), posl_spisok " +
				"tinyint(1), anketa_avtobiogr tinyint(1), photokartka tinyint(1), sp1 tinyint(1), " +
				"inshe varchar(250), oklad2 varchar(250), slugbova tinyint(1), atestuvan " +
				"varchar(250), 09_2004_oklad_vstan varchar(250), golosuvannia varchar(250), " +
				"stag_kalendar varchar(250), data_stag_kalendar varchar(250), medali " +
				"varchar(250), medali_mae varchar(250), visluga_cal_ovs_and_zs varchar(250), " +
				"FOREIGN KEY (id_in_zvan) REFERENCES zvan(id) ON DELETE CASCADE ON UPDATE " +
				"CASCADE) TYPE=INNODB DEFAULT CHARACTER SET cp1251 COLLATE cp1251_ukrainian_ci";
				*/
			try 
			{
				execSQL("DROP TABLE IF EXISTS zvan");
				execSQL("DROP TABLE IF EXISTS ljudyna");
				MySqlCommand cmd = new MySqlCommand(sql, conn);
				cmd.ExecuteNonQuery();
			}
			catch (Exception ex) 
			{
				Assert.Fail( ex.Message );
			}
			finally 
			{
				execSQL("DROP TABLE IF EXISTS zvan");
				execSQL("DROP TABLE IF EXISTS ljudyna");
			}
		}

		/// <summary>
		/// Bug #12245  	using Prepare() on an insert command causes null parameters to convert to "0"
		/// </summary>
		[Test]
		public void InsertingPreparedNulls()
		{
			execSQL("TRUNCATE TABLE test");
			MySqlCommand cmd = new MySqlCommand("INSERT INTO test VALUES(1, ?str)", conn);
			cmd.Parameters.Add("?str", MySqlDbType.VarChar);
			cmd.Prepare();

			cmd.Parameters[0].Value = null;
			cmd.ExecuteNonQuery();

			cmd.CommandText = "SELECT * FROM test";
			MySqlDataReader reader = null;
			try 
			{
				reader = cmd.ExecuteReader();
				Assert.IsTrue(reader.Read());
				Assert.AreEqual(DBNull.Value, reader[1]);
			}
			catch (Exception ex)
			{
				Assert.Fail(ex.Message);
			}
			finally 
			{
				if (reader != null) reader.Close();
			}
		}

		/// <summary>
		/// MySQL Bugs: #12163: Insert using prepared statement causes double insert
		/// </summary>
		[Test]
		public void PreparedInsertUsingReader()
		{
			execSQL("TRUNCATE TABLE test");
			MySqlCommand cmd = new MySqlCommand("INSERT INTO test VALUES(1, 'Test')", conn);
			cmd.Prepare();
			MySqlDataReader reader = cmd.ExecuteReader();
			reader.Close();

			cmd.CommandText = "SELECT * FROM test";
			reader = null;
			try 
			{
				reader = cmd.ExecuteReader();
				Assert.IsTrue(reader.Read());
				Assert.IsFalse(reader.Read());
				Assert.IsFalse(reader.NextResult());
			}
			catch (Exception ex)
			{
				Assert.Fail(ex.Message);
			}
			finally 
			{
				if (reader != null) reader.Close();
			}
		}

		/// <summary>
		/// Bug# 8119.  Unable to reproduce but left in anyway
		/// </summary>
		[Test]
		public void ReallyBigCommandString() 
		{
			System.Text.StringBuilder sql = new System.Text.StringBuilder();

			for (int i=0; i < 10; i++) 
				sql.Append("DROP TABLE IF EXISTS idx" + i + ";CREATE TABLE idx" + i + "(aa int not null auto_increment primary key, a int, b varchar(50), c int);");

			int c = 0;
			for (int z=0; z < 600; z++)
				for (int x=0; x < 10; x++, c++) 
				{
					string s = String.Format("INSERT INTO idx{0} (a, b, c) values ({1}, 'field{1}', {2});",
						x, z, c);
					sql.Append(s);
				}

			try 
			{
				MySqlCommand cmd = new MySqlCommand(sql.ToString(), conn);
				cmd.ExecuteNonQuery();
				
				for (int i=0; i < 10; i++) 
				{
					cmd.CommandText = "SELECT COUNT(*) FROM idx" + i;
					object count = cmd.ExecuteScalar();
					Assert.AreEqual( 600, count );
					execSQL("DROP TABLE IF EXISTS idx" + i );
				}
			}
			catch (Exception ex) 
			{
				Assert.Fail( ex.Message );
			}

		}

	}
}
