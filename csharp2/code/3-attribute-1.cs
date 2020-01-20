[System.AttributeUsage(System.AttributeTargets.Class |
        System.AttributeTargets.Struct)]
public class Author : System.Attribute{
    private string name;
    public double version;
    public Author(string name){
        this.name = name;
        version = 1.0;
    }
}

[Author("Tom", version = 1.1)]
class SampleClass{
    // Tom
}
