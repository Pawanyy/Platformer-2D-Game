using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Data;
using Mono.Data.Sqlite;
using System.IO;

public class DB : MonoBehaviour
{

    public int h = 0;
    public int c = 0;
    public string l = "";
    public Vector3 pos = new Vector3(0, 0, 0);
    // Start is called before the first frame update
    void Start()
    {
        TBcreate();
    }
    public void TBcreate()
    {
        string connection = Application.dataPath + "/database/game.s3db";
        //Debug.Log(connection);
        IDbConnection dbcon = new SqliteConnection("Data Source = " + connection);
        dbcon.Open();
        IDbCommand dbcmd;
        IDataReader reader;

        dbcmd = dbcon.CreateCommand();
        string q_createTable = "CREATE TABLE IF NOT EXISTS [mygame] ([save_id] INTEGER NOT NULL PRIMARY KEY,[health] INTEGER NOT NULL,[coins] INTEGER NOT NULL,[level] VARCHAR(20)  NOT NULL,[player_pos_x] FLOAT NOT NULL,[player_pos_y] FLOAT NOT NULL,[player_pos_z] FLOAT NOT NULL,[saved_bool] BOOLEAN NOT NULL)";
        dbcmd.CommandText = q_createTable;
        reader = dbcmd.ExecuteReader();
        dbcon.Close();
        
    }
    public void DBinsert(int h,int c,string l,float x, float y,float z,bool s)
    {
        DBdelete();TBcreate();

        string connection = Application.dataPath + "/database/game.s3db";
        IDbConnection dbcon = new SqliteConnection("Data Source = " + connection);
        dbcon.Open();
        IDbCommand dbcmd;
        IDataReader reader;
        dbcmd = dbcon.CreateCommand();
        string q_insert = "insert into mygame(save_id,health,coins,level,player_pos_x,player_pos_y,player_pos_z,saved_bool)" +
            "values(1,"+h+","+c+",'"+l+"',"+x+ "," + y + "," + z + ",'" +s+"');"; 
        dbcmd.CommandText = q_insert;
        reader = dbcmd.ExecuteReader();
        dbcon.Close();
    }
    public void DBdelete()
    {
        string connection = Application.dataPath + "/database/game.s3db";
        IDbConnection dbcon = new SqliteConnection("Data Source = " + connection);
        dbcon.Open();
        IDbCommand dbcmd;
        IDataReader reader;
        dbcmd = dbcon.CreateCommand();
        string q_insert = "drop table mygame; ";
        dbcmd.CommandText = q_insert;
        reader = dbcmd.ExecuteReader();
        dbcon.Close();
    }
    public void DBupdate()
    {
        DBdelete();
        TBcreate();
        
    }
    public void dbRead() 
    {
        
        string connection = Application.dataPath + "/database/game.s3db";
        IDbConnection dbcon = new SqliteConnection("Data Source = " + connection);
        dbcon.Open();
        IDbCommand dbcmd;
        IDataReader reader;
        dbcmd = dbcon.CreateCommand();
        string q_read = "select * from mygame;";
        dbcmd.CommandText = q_read;
        reader = dbcmd.ExecuteReader();
        while (reader.Read())
        {
            h = int.Parse(reader[1].ToString());
            c = int.Parse(reader[2].ToString());
            l = reader[3].ToString();
            pos = new Vector3(float.Parse(reader[4].ToString()), float.Parse(reader[5].ToString()), float.Parse(reader[6].ToString()));
        }
        dbcon.Close();

    }

}
