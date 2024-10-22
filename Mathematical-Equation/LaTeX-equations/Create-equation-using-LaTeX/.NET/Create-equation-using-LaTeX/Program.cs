﻿using Syncfusion.DocIO;
using Syncfusion.DocIO.DLS;


// Create a new Word document.
using (WordDocument document = new WordDocument())
{
    //Add one section and one paragraph to the document.
    document.EnsureMinimal();

    //Append an Fourier series equation using LaTeX.
    document.LastParagraph.AppendMath(@"f\left(x\right)={a}_{0}+\sum_{n=1}^{\infty}{\left({a}_{n}\cos{\frac{n\pi{x}}{L}}+{b}_{n}\sin{\frac{n\pi{x}}{L}}\right)}");

    //Save the Word document.
    using (FileStream outputStream = new FileStream(Path.GetFullPath(@"Output/Result.docx"), FileMode.Create, FileAccess.ReadWrite, FileShare.ReadWrite))
    {
        document.Save(outputStream, FormatType.Docx);
    }
}