>[!WARNING]
>Para correr la aplicación

- Realizar la creación de las bases de datos (<b>SchoolDB y SchoolIdentityDB</b>) por medio de <b>CodeFirst</b> con los comandos

  > En la consola del proyecto Infraestructure/Persistence
  ```sh
  Update-Database -Context ApplicationDbContext
  ```
  > En la consola del proyecto Infraestructure/Identity
  ```sh
  Update-Database -Context IdentityContext
  ```
- Al inciar el proyecto con WebApi como proyecto de inicio deben crearse usuarios con roles Administrator y Basic automáticamente en <b>SchoolIdentityDB</b>
- Para realizar la autenticación usar las credenciales en el endpoint "api/Account/authenticate"
  ```json
  {  "email": "admin@gmail.com",  "password": "P4$$w0rd" }
  ```
  ```json
  {  "email": "basic@gmail.com",  "password": "P4$$w0rd" }
  ```
  , el cual devuelve el token para el consumo de los endpoints de la API que están protegidos por estos roles
<hr/>
Se construye una <b>API REST</b> para cumplir las reglas de diseño que tiene el <b>estándar HTTP</b>.

- En la capa <b>Domain</b> se crean todas las entidades de dominio sin ninguna dependencia y sin lógica de código compleja, esta capa tiene el corazón de la aplicación
- En la capa <b>Application</b> está la implementación lógica del dominio para ofrecer las funcionalidades a las capas externas de Infrastructure
- En la capa <b>Infrastructure</b> usa todas las funcionalidades implementadas en Infraestructure, acá están los Controllers y la UI

Se usa el <b>patron CQRS</b> (Command Query Responsibility Segregation), es cual separa las acciones de lectura y actualización (Commands & Queries), esto ayuda a que la responsabilidad única de SOLID se pueda cumplir, en este proyecto está implementada para todas las entidades

<p>Se usa <b>patrón Mediator</b>, reduciendo la dependencia entre componentes que se desea sean independientes entre si, se utiliza cuando un Controller envía un command o query al modelo, de este modo existe un Handler que se encarga de hacer esta comunicación entre Controller y Modelo, el Handler además puede usar todas las herramientas necesarias para la comunicación correcta (dependencias)</p>

Se aplican los principios <b>SOLID</b><br />
- <b>Single responsibility:</b> Para la entidad Student, hay una clase (Student.cs) que se encarga de definir sus propiedades, otra clase (StudentConfig.cs) que describe como debe ser creada en el modelo de base de datos, otra (StudentDto.cs) la cual define las propiedades que serán expuestas a los Controllers o UI y otras clases (Commands y Queries) los que están encargados de implementar la lógica de creación, actualización, eliminación o búsqueda, por último otra clase (StudentsControllers.cs) la cual expone las acciones o endpoints que se realizan para esta entidad.</li>
- <b>Open/Closed:</b> Este principio se aplica, por ejemplo, en el contrato de IRepositoryAsync, el cual recibe una entidad y provee acciones para actualizar, crear, borrar o buscar un registro de dicha entidad, por lo cual si en un futuro queremos agregar una nueva entidad solo tenemos que crear la clase entidad para definir sus propiedades y el patrón IRepository se encarga de proveer todas las acciones sin necesidad de escribir código en el MyRepositoryAsync.</li>
- <b>Liskov Substitution:</b> Este se aplica en la herencia que hace la clase padre Exception a a sus clases hijas ApiException y ValidationException, las cuales sustituyen a su padre, una para mostrar errores generados en la Api cuando por ejemplo la base de datos devuelve un error y la otra para mostrar errores de validación de datos enviados desde el Controller, por ejemplo, cuando al crear un hotel enviamos parámetros incorrectos.</li>
- <b>Interface Segregation:</b> En esta aplicación IRepositoryAsync es una interfaz vacía que hace contrato con la interfaz IRepositoryBase (métodos de modificación) y esta a su vez hace contrato con IReadRepositoryBase (metodos de lectura), de esta forma cualquier entidad que haga contrato con IRepositoryAsync no está obligada a implementar todos los métodos de las interfaces base.</li>
- <b>Dependency Inversion:</b> Por ejemplo se usa en el servicio DateTimeService de modo que se crea un contrato con IDateTimeService el cual provee la hora a la aplicación, este servicio se puede inyectar en otras clases (<i>ApplicationDbContext</i>) a través de su constructor, la cual no debe crear nuevo código para obteneer la hora configurada por la aplicación.
</p>

Se usan los Nuget o librerías:
- MediatR, para implementar el patrón mediator
- AutoMapper, para hacer el mapeo de objetos
- FluentValidation, para hacer las validaciones de los parámetros enviados desde los Controller al modelo
- Ardalis.Specification, para la creación de consultas al modelo basadas en las entidades del dominio
- Se usa <b>Identity</b> de Microsoft para la autenticación a la API con el uso de <b>JsonWebToken</b>

