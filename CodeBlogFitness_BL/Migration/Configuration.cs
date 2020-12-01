using System;
using System.Data.Entity.Migrations;

internal sealed class Configuration : DbMigrationsConfiguration<CodeBlogFitness_BL.Controller.FitnessContext>
{
    public Configuration()
    {
        AutomaticMigrationsEnabled = true; //!! Not in to prod !!;
        ContextKey = "CodeBlogFitness_BL.Controller.FitnessContext";
    }

    protected override void Seed(CodeBlogFitness_BL.Controller.FitnessContext context)
    {

    }

}
