﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//     Versión de runtime:4.0.30319.42000
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
// </auto-generated>
//------------------------------------------------------------------------------

[assembly: global::System.Data.Objects.DataClasses.EdmSchemaAttribute()]

// Nombre de archivo original:
// Fecha de generación: 05/12/2018 12:26:21 p. m.
namespace challenge01Chapter12
{
    
    /// <summary>
    /// No hay ningún comentario para SchoolModel.Students en el esquema.
    /// </summary>
    /// <KeyProperties>
    /// StudentId
    /// </KeyProperties>
    [global::System.Data.Objects.DataClasses.EdmEntityTypeAttribute(NamespaceName="SchoolModel", Name="Students")]
    [global::System.Runtime.Serialization.DataContractAttribute(IsReference=true)]
    [global::System.Serializable()]
    public partial class Students : global::System.Data.Objects.DataClasses.EntityObject
    {
        /// <summary>
        /// Crear un nuevo objeto Students.
        /// </summary>
        /// <param name="studentId">Valor inicial de StudentId.</param>
        /// <param name="studentName">Valor inicial de StudentName.</param>
        [global::System.CodeDom.Compiler.GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        public static Students CreateStudents(int studentId, string studentName)
        {
            Students students = new Students();
            students.StudentId = studentId;
            students.StudentName = studentName;
            return students;
        }
        /// <summary>
        /// No hay ningún comentario para la propiedad StudentId en el esquema.
        /// </summary>
        [global::System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty=true, IsNullable=false)]
        [global::System.Runtime.Serialization.DataMemberAttribute()]
        [global::System.CodeDom.Compiler.GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        public int StudentId
        {
            get
            {
                return this._StudentId;
            }
            set
            {
                this.OnStudentIdChanging(value);
                this.ReportPropertyChanging("StudentId");
                this._StudentId = global::System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value);
                this.ReportPropertyChanged("StudentId");
                this.OnStudentIdChanged();
            }
        }
        [global::System.CodeDom.Compiler.GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        private int _StudentId;
        [global::System.CodeDom.Compiler.GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        partial void OnStudentIdChanging(int value);
        [global::System.CodeDom.Compiler.GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        partial void OnStudentIdChanged();
        /// <summary>
        /// No hay ningún comentario para la propiedad StudentName en el esquema.
        /// </summary>
        [global::System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(IsNullable=false)]
        [global::System.Runtime.Serialization.DataMemberAttribute()]
        [global::System.CodeDom.Compiler.GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        public string StudentName
        {
            get
            {
                return this._StudentName;
            }
            set
            {
                this.OnStudentNameChanging(value);
                this.ReportPropertyChanging("StudentName");
                this._StudentName = global::System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, false);
                this.ReportPropertyChanged("StudentName");
                this.OnStudentNameChanged();
            }
        }
        [global::System.CodeDom.Compiler.GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        private string _StudentName;
        [global::System.CodeDom.Compiler.GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        partial void OnStudentNameChanging(string value);
        [global::System.CodeDom.Compiler.GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        partial void OnStudentNameChanged();
    }
    /// <summary>
    /// No hay ningún comentario para SchoolEntity en el esquema.
    /// </summary>
    public partial class SchoolEntity : global::System.Data.Objects.ObjectContext
    {
        /// <summary>
        /// Inicializa un nuevo objeto SchoolEntity usando la cadena de conexión encontrada en la sección 'SchoolEntity' del archivo de configuración de la aplicación.
        /// </summary>
        public SchoolEntity() : 
                base("name=SchoolEntity", "SchoolEntity")
        {
            this.OnContextCreated();
        }
        /// <summary>
        /// Inicializar un nuevo objeto SchoolEntity.
        /// </summary>
        public SchoolEntity(string connectionString) : 
                base(connectionString, "SchoolEntity")
        {
            this.OnContextCreated();
        }
        /// <summary>
        /// Inicializar un nuevo objeto SchoolEntity.
        /// </summary>
        public SchoolEntity(global::System.Data.EntityClient.EntityConnection connection) : 
                base(connection, "SchoolEntity")
        {
            this.OnContextCreated();
        }
        partial void OnContextCreated();
        /// <summary>
        /// No hay ningún comentario para Students en el esquema.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        public global::System.Data.Objects.ObjectQuery<Students> Students
        {
            get
            {
                if ((this._Students == null))
                {
                    this._Students = base.CreateQuery<Students>("[Students]");
                }
                return this._Students;
            }
        }
        [global::System.CodeDom.Compiler.GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        private global::System.Data.Objects.ObjectQuery<Students> _Students;
        /// <summary>
        /// No hay ningún comentario para Students en el esquema.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        public void AddToStudents(Students students)
        {
            base.AddObject("Students", students);
        }
    }
}
