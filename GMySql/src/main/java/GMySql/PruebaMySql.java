package GMySql;

import java.sql.Connection;
import java.sql.DriverManager;
import java.sql.PreparedStatement;
import java.sql.ResultSet;
import java.sql.SQLException;
import java.sql.Statement;

public class PruebaMySql {
	static Connection connection;
	public static void main(String[] args) throws SQLException {
		String url = "jdbc:mysql://localhost/db_prueba?serverTimezone=UTC";
		connection = DriverManager.getConnection(url, "root", "sistemas");
		
		ShowAll();
		
		connection.close();
	}

	private static void ShowAll() throws SQLException {
		Statement statement = connection.createStatement();
		ResultSet resultSet = statement.executeQuery("select * from categoria order by id");

		while (resultSet.next()) {
			System.out.printf("id=%s, nombre=%s%n", resultSet.getLong(1), resultSet.getString(2));
		}
		statement.close();
	}
	
	private static void Insert() throws SQLException {
		PreparedStatement preparedStatement = connection.prepareStatement("insert into categoria (nombre) values (?)");
	}
}
