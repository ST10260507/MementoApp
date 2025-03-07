namespace Memento
{
    public class Editor
    {
        public string Content {get; set;} = "";

        public void SetText(string text)
        {
            Content = text;
        }

        public MementoText Save ()
        {
            return new MementoText(Content);
        }

        public void Restore(MementoText memento)
        {
            if(memento != null)
            {
               Content = memento.Content; 
            }
            
        }
    }
}