public class Measure
{
    public string Name { get; set; }
    public string Description { get; set; }
    public string Pros { get; set; }
    public string Cons { get; set; }
    public float InfectionPercentage { get; set; }
    public float Radius { get; set; }
    public float Happiness { get; set; }

    public readonly Measure[] measures =
    {
        new Measure { Name="Social Distancing", Description="People must be 1m apart.", Pros="Radius of contact will be expanded to 1m.", Cons="", InfectionPercentage=0f, Radius=1f, Happiness=0f },
        new Measure { Name="Social Distancing", Description="People must be 2m apart.", Pros="Radius of contact will be expanded to 2m.", Cons="", InfectionPercentage=0f, Radius=2f, Happiness=0f },
        new Measure { Name="Social Distancing", Description="People must be 3m apart.", Pros="Radius of contact will be expanded to 3m.", Cons="P" , InfectionPercentage=0f, Radius=3f, Happiness=0f },
        new Measure { Name="Masks", Description="People are RECOMMENDED to wear masks.", Pros="Infection will be reduced by 5%", Cons="", InfectionPercentage=0f, Radius=1f, Happiness=0f },
        new Measure { Name="Masks", Description="People are OBLIGED to wear masks.", Pros="Infection will be reduced by 10%", Cons="", InfectionPercentage=0f, Radius=1f, Happiness=0f },
        new Measure { Name="Fully equipped", Description="People are OBLIGED to wear masks and gloves.", Pros="Infection will be reduced by 20%", Cons="", InfectionPercentage=0f, Radius=1f, Happiness=0f },
        new Measure { Name="Wash your hands!", Description="People are RECOMMENDED to wash hands.", Pros="Infection will be reduced by 5%", Cons="", InfectionPercentage=0f, Radius=1f, Happiness=0f },
        new Measure { Name="Wash your hands!", Description="People are OBLIGED to wash hands.", Pros="Infection will be reduced by 10%", Cons="", InfectionPercentage=0f, Radius=1f, Happiness=0f },
        new Measure { Name="Sanitize", Description="People are OBLIGED to wash hands and use sanitary products.", Pros="Infection will be reduced by 20%", Cons="", InfectionPercentage=0f, Radius=1f, Happiness=0f },
        new Measure { Name="#stayathome", Description="People are RECOMMENDED to stay at home.", Pros="Infection will be reduced by 5%", Cons="", InfectionPercentage=0f, Radius=1f, Happiness=0f },
        new Measure { Name="#stayathome", Description="People are OBLIGED to stay at home.", Pros="Infection will be reduced by 5%", Cons="", InfectionPercentage=0f, Radius=1f, Happiness=0f },
        new Measure { Name="Isolation", Description="People must completely isolate at home if they are infected.", Pros="Infection will be reduced by 5%", Cons="", InfectionPercentage=0f, Radius=1f, Happiness=0f },
        new Measure { Name="Clean it up!", Description="Workers have to clean their workspace after every workday.", Pros="", Cons="", InfectionPercentage=0f, Radius=1f, Happiness=0f },
        new Measure { Name="Clean it up!", Description="Workers have to to clean their workspace after every product usage.", Pros="", Cons="", InfectionPercentage=0f, Radius=1f, Happiness=0f },
        new Measure { Name="Cristal clear", Description="Workers must completely sanitize their workspace and products.", Pros="", Cons="", InfectionPercentage=0f, Radius=1f, Happiness=0f },
    };
}
