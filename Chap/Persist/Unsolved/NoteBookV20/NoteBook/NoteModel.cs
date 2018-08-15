using System.Collections.Generic;
using System.Linq;

namespace NoteBook
{
    public class NoteModel
    {
        #region Instance fields
        private Dictionary<string, Note> _notes;
        private IDataSource<Note> _source;
        #endregion

        #region Constructor
        public NoteModel()
        {
            _notes = new Dictionary<string, Note>();
            _source = new FilePersistency<Note>();
        }
        #endregion

        #region Properties
        public List<Note> All
        {
            get { return _notes.Values.ToList(); }
        }
        #endregion

        #region Methods
        public async void LoadAsync()
        {
            List<Note> notes = await _source.LoadAsync();
            Clear();
            notes.ForEach(Add);
        }

        public async void SaveAsync()
        {
            await _source.SaveAsync(All);
        }

        public void Add(Note aNote)
        {
            if (!_notes.ContainsKey(aNote.Title))
            {
                _notes.Add(aNote.Title, aNote);
            }
        }

        public void Delete(string title)
        {
            _notes.Remove(title);
        }

        public Note Read(string title)
        {
            return _notes.ContainsKey(title) ? _notes[title] : null;
        }

        public void Clear()
        {
            _notes.Clear();
        }

        public bool ContainsTitle(string title)
        {
            return _notes.ContainsKey(title);
        }
        
        public void UpdateTitle(string oldTitle, string newTitle)
        {
            // The title is updated by:
            // 1) Deleting the note with the existing title
            // 2) Adding a new note with the new title AND the existing content
            Note aNote = Read(oldTitle);
            if (aNote != null)
            {
                string content = aNote.Content;
                Delete(oldTitle);
                Add(new Note(newTitle, content));
            }
        }
        #endregion
    }
}
