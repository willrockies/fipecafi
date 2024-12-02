# Teste Fipecafi 2024


- Alguns passo necessario para rodar a API 
 - foi criado um instancia de SQL, para que os dados persista na base, pode alterar para a instancia do sql de seu computador local no arquivo  DependencyInjectionExtension no projeto de "fipecafi.infrastructure" alterando a connectionString 

   var connectionString = "Data Source=DESKTOP-A0C6ICI\\FIPECAFI;Initial Catalog=fipecafi;User ID=sa;Password=@cesso123;Trusted_Connection=True;Encrypt=True;TrustServerCertificate=True;";

# Data Source=<Nome da instancia  banco de dados>
# Initial Catalog=<no do banco de dados>
# User ID=<por padrão o id é SA, caso não tenha não preencher>
# Password=<caso não tenha não preencher>;


# como os requisitos de database first segue os scripts de criação da tabela no banco de dados que está sendo utilizando 



 # tabela de cadastro de alunos

   <!-- USE [nomedobancodedados] -->
GO

/****** Object:  Table [dbo].[Alunos]    Script Date: 02/12/2024 17:55:50 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Alunos](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CodigoMatricula] [int] NOT NULL,
	[Nome] [nvarchar](100) NOT NULL,
	[Telefone] [nvarchar](20) NOT NULL,
	[Email] [nvarchar](100) NOT NULL,
	[CursoId] [int] NOT NULL,
	[TurmaId] [int] NOT NULL,
	[DataCadastro] [datetime] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[CodigoMatricula] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Alunos] ADD  DEFAULT (getdate()) FOR [DataCadastro]
GO

ALTER TABLE [dbo].[Alunos]  WITH CHECK ADD FOREIGN KEY([CursoId])
REFERENCES [dbo].[Cursos] ([Id])
GO

ALTER TABLE [dbo].[Alunos]  WITH CHECK ADD FOREIGN KEY([TurmaId])
REFERENCES [dbo].[Turmas] ([Id])
GO


# Tabela de Cursos
 <!-- USE [nomedobancodedados] -->
GO


SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Cursos](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Descricao] [nvarchar](100) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

# para tabela de cursos necessario inserir dados hardcoded
 <!-- USE [nomedobancodedados] -->
GO

INSERT INTO [dbo].[Cursos]
           ([Descricao])
     VALUES
           ('ADS')
GO




# Tabela de Leads

<!-- USE [nomedobancodedados] -->
GO


SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Leads](
	[Nome] [nvarchar](100) NOT NULL,
	[Telefone] [nvarchar](20) NOT NULL,
	[Email] [nvarchar](100) NOT NULL,
	[CursoId] [int] NOT NULL,
	[Id] [int] IDENTITY(1,1) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Leads]  WITH CHECK ADD FOREIGN KEY([CursoId])
REFERENCES [dbo].[Cursos] ([Id])
GO



# tabela de turmas 
<!-- USE [nomedobancodedados] -->
GO

/****** Object:  Table [dbo].[Turmas]    Script Date: 02/12/2024 18:03:59 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Turmas](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Descricao] [nvarchar](100) NOT NULL,
	[CursoId] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Turmas]  WITH CHECK ADD FOREIGN KEY([CursoId])
REFERENCES [dbo].[Cursos] ([Id])
GO

# para tabela de turma necessario inserir dados hardcoded

<!-- USE [nomedobancodedados] -->
GO

INSERT INTO [dbo].[Turmas]
           ([Descricao]
           ,[CursoId])
     VALUES
           ('Turma manhã'
           ,1)
INSERT INTO [dbo].[Turmas]
           ([Descricao]
           ,[CursoId])
     VALUES
           ('Turma noite'
           ,1)
GO




