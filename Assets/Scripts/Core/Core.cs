public class Core
{
    public static Core Instance
    {
        get
        {
            if(_instance == null)
                _instance = new Core();
            return _instance;
        }
    }

    private static Core _instance;

    private Core() { }
}
