namespace SeeSharpHistory;

class PropertiesCS1 // .NET Framework v1
{
    private string _name;

    public string Name
    {
        get { return _name; }
        set { _name = value; }
    }

    private string _readonlyValue;

    public string ReadOnlyValue
    {
        get { return _readonlyValue; }
        private set { _readonlyValue = value; }
    }
}

class PropertiesCS2
{
    public string Name
    {
        get;
        set;
    }


}


class PropertiesCS3
{
    public string Name
    {
        get;
        set;
    }


    public string ReadOnlyValue
    {
        get;
    } = "Value";


    public PropertiesCS3()
    {
        ReadOnlyValue = "VAlue";
    }

}
