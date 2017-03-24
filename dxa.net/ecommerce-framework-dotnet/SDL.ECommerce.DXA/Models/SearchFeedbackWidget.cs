using Sdl.Web.Common.Models;
using Sdl.ECommerce.Api.Model;

using System.Collections.Generic;

namespace Sdl.ECommerce.Dxa
{
    /// <summary>
    /// Search Feedback Widget
    /// </summary>
    [SemanticEntity(Vocab = CoreVocabulary, EntityName = "SearchFeedbackWidget", Prefix = "e")]
    public class SearchFeedbackWidget : EntityModel
    {
        [SemanticProperty("e:spellCheckLabel")]
        public RichText SpellCheckLabel { get; set; }

        [SemanticProperty(IgnoreMapping = true)]
        public IList<IQuerySuggestion> QuerySuggestions { get; set; } 
    }
}