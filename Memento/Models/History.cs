namespace Memento
{
    public class History 
    {
        private readonly Stack<MementoText> history = new Stack<MementoText>();

        public void Save(MementoText memento)
        {
            history.Push(memento);
        }

        public MementoText Undo()
        {
            return history.Count > 0 ? history.Pop() : null;
        }

        public List <String> GetHistory()
        {
            //return history.Select(memento => memento.Content).ToList();
            List <string> historyList = new List<string>();
            foreach (var memento in history)
            {
                historyList.Add(memento.Content);
            }
            return historyList;
        }

        public MementoText GetPeek()
        {
            if(history.Count > 0)
            {
                return history.Peek();
            }
            return null;
        }

        public bool CanUndo()
        {
            return history.Count > 0;
        }
    }
    
}