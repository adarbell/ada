package GMySql;

public class App {
    private static App instance = new App();

    public static App GetInstance() {
        if (null == instance) {
            instance = new App();
        }
        return instance;
    }
}
