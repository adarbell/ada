using System;
using System.Collections.Generic;
using System.Data;
using CGtk;
using Gtk;
using Serpis.Ad;

public partial class MainWindow : Gtk.Window
{
    public static ListStore listStore { get; private set; }
    public static List<Categoria> categorias;

    public MainWindow() : base(Gtk.WindowType.Toplevel)
    {
        Build();
 
        treeView.AppendColumn("ID", new CellRendererText(), "text", 0);
        treeView.AppendColumn("Nombre", new CellRendererText(), "text", 1);

        listStore = new ListStore(typeof(string), typeof(string));

        treeView.Model = listStore;
        OnInit();

        newAction.Activated += (sender, e) => new CGtk.CategoriaWindow();
        editAction.Activated += (sender, e) =>
        {
            object value = TreeViewHelper.GetValue(treeView, "Nombre");
            Console.WriteLine("editAction Activated Nombre = " + value);
        };
        deleteAction.Activated += (sender, e) => treeView.Remove((Gtk.Widget)TreeViewHelper.GetValue(treeView, "ID"));
        refreshAction.Activated += (sender, e) => OnInit();
        quitAction.Activated += (sender, e) => Application.Quit();
    }

    protected void OnDeleteEvent(object sender, DeleteEventArgs a)
    {
        Application.Quit();
        a.RetVal = true;
    }
    protected static void OnInit()
    {
        Conexion.Conectarse();

        categorias = new List<Categoria>();
        listStore.Clear();

        IDbCommand dbCommand = Conexion.dbConnection.CreateCommand();
        dbCommand.CommandText = "select * from categoria";
        IDataReader dr = dbCommand.ExecuteReader();

        while (dr.Read())
            categorias.Add(new Categoria((ulong)dr["id"], (string)dr["nombre"]));
        dr.Close();

        foreach (var cat in categorias)
            listStore.AppendValues(cat.Id.ToString(), cat.Nombre);

        Conexion.Desconectarse();
    }
}
