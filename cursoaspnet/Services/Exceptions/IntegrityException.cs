using System;

namespace cursoaspnet.Services.Exceptions {
    public class IntegrityException : ApplicationException {

        public IntegrityException(string message) : base(message) {

        }
    }
}
