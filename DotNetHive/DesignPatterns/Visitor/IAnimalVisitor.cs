namespace DotNetHive.DesignPatterns.Visitor
{
    internal interface IAnimalVisitor
    {
        void Visit(Bear bear);
        void Visit(Lion lion);
    }
}
