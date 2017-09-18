namespace SurveyLib2.interfaces
{
    public interface IParentable
    {
        void AddChild(objects.SurveyObjectBase item);        
        objects.SurveyObjectBase AddChild(string title);        
    }
}
