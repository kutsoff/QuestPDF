﻿using QuestPDF.Infrastructure;

namespace QuestPDF.Elements
{
    internal sealed class Section : ContainerElement, IStateResettable
    {
        public string SectionName { get; set; }
        private bool IsRendered { get; set; }
        
        public void ResetState(bool hardReset)
        {
            IsRendered = false;
        }
        
        internal override void Draw(Size availableSpace)
        {
            if (!IsRendered)
            {
                var targetName = PageContext.GetDocumentLocationName(SectionName);
                Canvas.DrawSection(targetName);
                IsRendered = true;
            }
            
            PageContext.SetSectionPage(SectionName);
            base.Draw(availableSpace);
        }
    }
}