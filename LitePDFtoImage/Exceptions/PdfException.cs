﻿using System;
using static PDFtoImage.Internals.NativeMethods;

namespace PDFtoImage.Exceptions
{
    /// <summary>
    /// Base class for all PDF related exceptions.
    /// </summary>
    /// <inheritdoc/>
    public abstract class PdfException(string message) : Exception(message)
    {
        internal abstract FPDF_ERR Error { get; }

        internal static PdfException? CreateException(FPDF_ERR error) => error switch
        {
            FPDF_ERR.SUCCESS => null,
            FPDF_ERR.UNKNOWN => new PdfUnknownException(),
            FPDF_ERR.FILE => new PdfCannotOpenFileException(),
            FPDF_ERR.FORMAT => new PdfInvalidFormatException(),
            FPDF_ERR.PASSWORD => new PdfPasswordProtectedException(),
            FPDF_ERR.SECURITY => new PdfUnsupportedSecuritySchemeException(),
            FPDF_ERR.PAGE => new PdfPageNotFoundException(),
            _ => new PdfUnknownException()
        };
    }
}