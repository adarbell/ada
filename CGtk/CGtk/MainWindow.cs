using System;
using System.Collections.Generic;
using System.Data;
using CGtk;
using Gtk;

public partial class MainWindow : Gtk.Window
{
    public static ListStore listStore { get; private set; }
    public static List<Categoria> categorias = new List<Categoria>();

    public MainWindow() : base(Gtk.WindowType.Toplevel)
    {
        Build();

        treeView.AppendColumn("ID", new CellRendererText(), "text", 0);
        treeView.AppendColumn("Nombre", new CellRendererText(), "text", 1);

        listStore = new ListStore(typeof(string), typeof(string));

        treeView.Model = listStore;
        onInit();

        newAction.Activated += (sender, e) => new CGtk.CategoriaWindow();
        quitAction.Activated += (sender, e) => Application.Quit();
    }

    protected void OnDeleteEvent(object sender, DeleteEventArgs a)
    {
        Application.Quit();
        a.RetVal = true;
    }

    private static void onInit()
    {
        Conexion.Conectarse();

        IDbCommand dbCommand = Conexion.dbConnection.CreateCommand();
        dbCommand.CommandText = "select * from categoria";
        IDataReader dr = dbCommand.ExecuteReader();

        while (dr.Read())
        {
            categorias.Add(new Categoria((ulong)dr["id"], (string)dr["nombre"]));
        }
        dr.Close();

        foreach (var cat in categorias)
        {
            listStore.AppendValues(cat.Id.ToString(), cat.Nombre);
        }
    }
}
