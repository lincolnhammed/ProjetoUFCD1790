-- =====================================
-- RESET BASE DE DADOS
-- =====================================
DROP DATABASE IF EXISTS Projeto_UFCD1790;
CREATE DATABASE Projeto_UFCD1790;
USE Projeto_UFCD1790;

-- =====================================
-- TABELA LOGIN
-- =====================================
CREATE TABLE login (
    id INT PRIMARY KEY AUTO_INCREMENT,
    usuario VARCHAR(100) NOT NULL,
    senha VARCHAR(255) NOT NULL
);

-- =====================================
-- TABELA USUARIO
-- =====================================
CREATE TABLE usuario (
    id INT PRIMARY KEY AUTO_INCREMENT,
    nome VARCHAR(100) NOT NULL,
    is_admin BOOLEAN DEFAULT FALSE,
    id_login INT NOT NULL,
    FOREIGN KEY (id_login) REFERENCES login(id)
);

-- =====================================
-- TABELA RESULTADO
-- =====================================
CREATE TABLE resultado (
    id INT PRIMARY KEY AUTO_INCREMENT,
    categoria VARCHAR(50) NOT NULL,
    totalPerguntas INT NOT NULL,
    acertos INT NOT NULL,
    percentagem DOUBLE,
    id_usuario INT NOT NULL,
    data_realizacao DATETIME DEFAULT CURRENT_TIMESTAMP,
    FOREIGN KEY (id_usuario) REFERENCES usuario(id)
);

-- =====================================
-- TABELA CATEGORIA
-- =====================================
CREATE TABLE categoria (
    id INT PRIMARY KEY AUTO_INCREMENT,
    nome VARCHAR(50) NOT NULL
);

-- =====================================
-- TABELA PERGUNTA
-- =====================================
CREATE TABLE pergunta (
    id INT PRIMARY KEY AUTO_INCREMENT,
    pergunta TEXT NOT NULL,
    id_categoria INT NOT NULL,
    FOREIGN KEY (id_categoria) REFERENCES categoria(id)
);

-- =====================================
-- TABELA RESPOSTA
-- =====================================
CREATE TABLE resposta (
    id INT PRIMARY KEY AUTO_INCREMENT,
    resposta TEXT NOT NULL,
    correta BOOLEAN DEFAULT FALSE,
    id_pergunta INT NOT NULL,
    FOREIGN KEY (id_pergunta) REFERENCES pergunta(id)
);

-- =====================================
-- INSERT LOGIN + USUARIO
-- =====================================
INSERT INTO login (usuario, senha) VALUES ('lincoln', '123456');

INSERT INTO usuario (nome, is_admin, id_login)
VALUES ('Lincoln Silva', true, 1);

-- =====================================
-- INSERT CATEGORIAS
-- =====================================
INSERT INTO categoria (nome) VALUES 
('Geografia'),
('História'),
('Tecnologia');

-- =====================================
-- INSERT PERGUNTAS
-- =====================================
INSERT INTO pergunta (pergunta, id_categoria) VALUES
('Qual é a capital de Portugal?', 1),
('Qual é o maior país do mundo?', 1),
('Qual continente é o Brasil?', 1),
('Qual é o maior oceano?', 1),
('Qual país tem formato de bota?', 1),

('Quem descobriu o Brasil?', 2),
('Em que ano começou a Segunda Guerra Mundial?', 2),
('Quem foi Napoleão?', 2),
('Qual civilização construiu as pirâmides?', 2),
('Quem foi o primeiro presidente do Brasil?', 2),

('O que significa CPU?', 3),
('Qual linguagem é usada para web?', 3),
('O que é RAM?', 3),
('O que significa HTML?', 3),
('Qual destes é um sistema operativo?', 3);

-- =====================================
-- INSERT RESPOSTAS
-- =====================================
-- GEOGRAFIA
INSERT INTO resposta (resposta, correta, id_pergunta) VALUES
('Lisboa', TRUE, 1), ('Porto', FALSE, 1), ('Faro', FALSE, 1), ('Coimbra', FALSE, 1),
('Rússia', TRUE, 2), ('Brasil', FALSE, 2), ('China', FALSE, 2), ('EUA', FALSE, 2),
('América do Sul', TRUE, 3), ('Europa', FALSE, 3), ('Ásia', FALSE, 3), ('África', FALSE, 3),
('Pacífico', TRUE, 4), ('Atlântico', FALSE, 4), ('Índico', FALSE, 4), ('Ártico', FALSE, 4),
('Itália', TRUE, 5), ('Espanha', FALSE, 5), ('França', FALSE, 5), ('Alemanha', FALSE, 5);

-- HISTÓRIA
INSERT INTO resposta (resposta, correta, id_pergunta) VALUES
('Pedro Álvares Cabral', TRUE, 6), ('Colombo', FALSE, 6), ('Vasco da Gama', FALSE, 6), ('Dom Pedro I', FALSE, 6),
('1939', TRUE, 7), ('1914', FALSE, 7), ('1945', FALSE, 7), ('1920', FALSE, 7),
('Imperador francês', TRUE, 8), ('Rei inglês', FALSE, 8), ('Papa', FALSE, 8), ('General romano', FALSE, 8),
('Egípcios', TRUE, 9), ('Romanos', FALSE, 9), ('Gregos', FALSE, 9), ('Maias', FALSE, 9),
('Deodoro da Fonseca', TRUE, 10), ('Getúlio Vargas', FALSE, 10), ('Dom Pedro II', FALSE, 10), ('Lula', FALSE, 10);

-- TECNOLOGIA
INSERT INTO resposta (resposta, correta, id_pergunta) VALUES
('Unidade Central de Processamento', TRUE, 11), ('Memória', FALSE, 11), ('Disco', FALSE, 11), ('Placa de vídeo', FALSE, 11),
('JavaScript', TRUE, 12), ('C++', FALSE, 12), ('Python', FALSE, 12), ('Java', FALSE, 12),
('Memória temporária', TRUE, 13), ('Disco rígido', FALSE, 13), ('Processador', FALSE, 13), ('Fonte', FALSE, 13),
('Linguagem de marcação', TRUE, 14), ('Banco de dados', FALSE, 14), ('Sistema operativo', FALSE, 14), ('Servidor', FALSE, 14),
('Windows', TRUE, 15), ('Google', FALSE, 15), ('Intel', FALSE, 15), ('Facebook', FALSE, 15);
-- =====================================
-- RESET BASE DE DADOS
-- =====================================
DROP DATABASE IF EXISTS ProjetoUFCD1790;
CREATE DATABASE ProjetoUFCD1790;
USE ProjetoUFCD1790;

-- =====================================
-- TABELAS
-- =====================================

CREATE TABLE login (
    id INT PRIMARY KEY AUTO_INCREMENT,
    usuario VARCHAR(100) NOT NULL,
    senha VARCHAR(255) NOT NULL
);

CREATE TABLE usuario (
    id INT PRIMARY KEY AUTO_INCREMENT,
    nome VARCHAR(100) NOT NULL,
    is_admin BOOLEAN DEFAULT FALSE,
    id_login INT NOT NULL,
    FOREIGN KEY (id_login) REFERENCES login(id)
);

CREATE TABLE resultado (
    id INT PRIMARY KEY AUTO_INCREMENT,
    categoria VARCHAR(50) NOT NULL,
    totalPerguntas INT NOT NULL,
    acertos INT NOT NULL,
    percentagem DOUBLE,
    id_usuario INT NOT NULL,
    data_realizacao DATETIME DEFAULT CURRENT_TIMESTAMP,
    FOREIGN KEY (id_usuario) REFERENCES usuario(id)
);

CREATE TABLE categoria (
    id INT PRIMARY KEY AUTO_INCREMENT,
    nome VARCHAR(50) NOT NULL
);

CREATE TABLE pergunta (
    id INT PRIMARY KEY AUTO_INCREMENT,
    pergunta TEXT NOT NULL,
    id_categoria INT NOT NULL,
    FOREIGN KEY (id_categoria) REFERENCES categoria(id)
);

CREATE TABLE resposta (
    id INT PRIMARY KEY AUTO_INCREMENT,
    resposta TEXT NOT NULL,
    correta BOOLEAN DEFAULT FALSE,
    id_pergunta INT NOT NULL,
    FOREIGN KEY (id_pergunta) REFERENCES pergunta(id)
);

-- =====================================
-- INSERTS
-- =====================================

INSERT INTO login (usuario, senha) VALUES ('lincoln', '123456');

INSERT INTO usuario (nome, is_admin, id_login)
VALUES ('Lincoln Silva', FALSE, 1);

INSERT INTO categoria (nome) VALUES 
('Geografia'),
('História'),
('Tecnologia');

INSERT INTO pergunta (pergunta, id_categoria) VALUES
('Qual é a capital de Portugal?', 1),
('Qual é o maior país do mundo?', 1),
('Qual continente é o Brasil?', 1),
('Qual é o maior oceano?', 1),
('Qual país tem formato de bota?', 1),
('Quem descobriu o Brasil?', 2),
('Em que ano começou a Segunda Guerra Mundial?', 2),
('Quem foi Napoleão?', 2),
('Qual civilização construiu as pirâmides?', 2),
('Quem foi o primeiro presidente do Brasil?', 2),
('O que significa CPU?', 3),
('Qual linguagem é usada para web?', 3),
('O que é RAM?', 3),
('O que significa HTML?', 3),
('Qual destes é um sistema operativo?', 3);

-- respostas
INSERT INTO resposta (resposta, correta, id_pergunta) VALUES
('Lisboa', TRUE, 1), ('Porto', FALSE, 1), ('Faro', FALSE, 1), ('Coimbra', FALSE, 1),
('Rússia', TRUE, 2), ('Brasil', FALSE, 2), ('China', FALSE, 2), ('EUA', FALSE, 2),
('América do Sul', TRUE, 3), ('Europa', FALSE, 3), ('Ásia', FALSE, 3), ('África', FALSE, 3),
('Pacífico', TRUE, 4), ('Atlântico', FALSE, 4), ('Índico', FALSE, 4), ('Ártico', FALSE, 4),
('Itália', TRUE, 5), ('Espanha', FALSE, 5), ('França', FALSE, 5), ('Alemanha', FALSE, 5),

('Pedro Álvares Cabral', TRUE, 6), ('Colombo', FALSE, 6), ('Vasco da Gama', FALSE, 6), ('Dom Pedro I', FALSE, 6),
('1939', TRUE, 7), ('1914', FALSE, 7), ('1945', FALSE, 7), ('1920', FALSE, 7),
('Imperador francês', TRUE, 8), ('Rei inglês', FALSE, 8), ('Papa', FALSE, 8), ('General romano', FALSE, 8),
('Egípcios', TRUE, 9), ('Romanos', FALSE, 9), ('Gregos', FALSE, 9), ('Maias', FALSE, 9),
('Deodoro da Fonseca', TRUE, 10), ('Getúlio Vargas', FALSE, 10), ('Dom Pedro II', FALSE, 10), ('Lula', FALSE, 10),

('Unidade Central de Processamento', TRUE, 11), ('Memória', FALSE, 11), ('Disco', FALSE, 11), ('Placa de vídeo', FALSE, 11),
('JavaScript', TRUE, 12), ('C++', FALSE, 12), ('Python', FALSE, 12), ('Java', FALSE, 12),
('Memória temporária', TRUE, 13), ('Disco rígido', FALSE, 13), ('Processador', FALSE, 13), ('Fonte', FALSE, 13),
('Linguagem de marcação', TRUE, 14), ('Banco de dados', FALSE, 14), ('Sistema operativo', FALSE, 14), ('Servidor', FALSE, 14),
('Windows', TRUE, 15), ('Google', FALSE, 15), ('Intel', FALSE, 15), ('Facebook', FALSE, 15);

-- =====================================
-- QUERIES 
-- =====================================

-- DELETE USUARIO
DELETE FROM usuario WHERE id_login = 1;

-- UPDATE COM JOIN
UPDATE usuario u
INNER JOIN login l ON u.id_login = l.id
SET u.nome = 'Teste', u.is_admin = TRUE, l.usuario = 'novo', l.senha = '123'
WHERE u.id = 2;

-- SELECT POR ID
SELECT u.id, u.nome, u.is_admin, l.usuario, l.senha
FROM usuario u
INNER JOIN login l ON u.id_login = l.id
WHERE u.id = 1;

-- LISTAR TODOS
SELECT l.id, u.nome, u.is_admin, l.usuario, l.senha
FROM usuario u
INNER JOIN login l ON u.id_login = l.id;

-- INSERT USUARIO
INSERT INTO usuario (nome, is_admin, id_login)
VALUES ('Novo User', FALSE, 1);

-- INSERT RESULTADO
INSERT INTO resultado (categoria, totalPerguntas, acertos, percentagem, id_usuario)
VALUES ('Geografia', 5, 4, 80, 1);

-- SELECT RESULTADOS POR USER
SELECT id_usuario, categoria, totalPerguntas, acertos, percentagem, data_realizacao
FROM resultado
WHERE id_usuario = 1;

-- RESPOSTAS
SELECT * FROM resposta WHERE id_pergunta = 1 ORDER BY RAND();

-- PERGUNTAS
SELECT * FROM pergunta WHERE id_categoria = 1 ORDER BY RAND() limit 10;

-- DELETE LOGIN
DELETE FROM login WHERE id = 1;

-- INSERT LOGIN
INSERT INTO login (usuario, senha) VALUES ('user2', '123');

-- LOGIN (VALIDAÇÃO)
SELECT u.
id as usuario_id, u.nome as nomeUsuario, l.id as login_id, l.usuario
FROM login l
INNER JOIN usuario u ON u.id_login = l.id
WHERE l.usuario = 'lincoln' AND l.senha = '123';

-- CATEGORIAS
SELECT id, nome FROM categoria;

-- RESULTADOS
SELECT * FROM resultado;

-- USUARIOS
SELECT * FROM usuario;

-- LOGIN
SELECT * FROM login;

-- PERGUNTAS
SELECT * FROM pergunta;
-- =====================================
-- NOVAS PERGUNTAS (60)
-- =====================================

INSERT INTO pergunta (id, pergunta, id_categoria) VALUES

-- GEOGRAFIA (16-35)
(16,'Qual é o rio mais longo do mundo?',1),
(17,'Qual país tem mais habitantes?',1),
(18,'Qual é o menor país do mundo?',1),
(19,'Qual é a montanha mais alta do mundo?',1),
(20,'Onde fica a Torre Eiffel?',1),
(21,'Qual é o maior deserto do mundo?',1),
(22,'Qual país tem a cidade de Nova Iorque?',1),
(23,'Qual é a capital do Japão?',1),
(24,'Qual oceano banha Portugal?',1),
(25,'Qual é o maior continente?',1),
(26,'Qual país tem formato de bota?',1),
(27,'Qual é a capital da Espanha?',1),
(28,'Qual é a capital da Alemanha?',1),
(29,'Qual é a capital da Itália?',1),
(30,'Qual país fica na América do Norte?',1),
(31,'Qual é o maior lago do mundo?',1),
(32,'Qual é a capital do Brasil?',1),
(33,'Qual é a capital da França?',1),
(34,'Qual país tem mais ilhas?',1),
(35,'Qual é o ponto mais alto da Terra?',1),

-- HISTÓRIA (36-55)
(36,'Quem foi o primeiro imperador de Roma?',2),
(37,'Quem descobriu a América?',2),
(38,'Em que ano caiu o Império Romano?',2),
(39,'Quem foi Júlio César?',2),
(40,'Qual foi a guerra entre EUA e URSS?',2),
(41,'Quem foi Dom Pedro I?',2),
(42,'Quem foi Gandhi?',2),
(43,'Quem liderou a Alemanha na WWII?',2),
(44,'Qual civilização criou a democracia?',2),
(45,'Quem foi Alexandre, o Grande?',2),
(46,'Qual país colonizou o Brasil?',2),
(47,'Quem foi Churchill?',2),
(48,'Qual foi a Primeira Guerra Mundial?',2),
(49,'Quem foi Karl Marx?',2),
(50,'Qual civilização construiu Machu Picchu?',2),
(51,'Quem foi Cleópatra?',2),
(52,'Qual império dominou a Europa antiga?',2),
(53,'Quem foi o primeiro homem na Lua?',2),
(54,'Quem foi Napoleão?',2),
(55,'Qual foi o evento de 1789?',2),

-- TECNOLOGIA (56-75)
(56,'O que é um algoritmo?',3),
(57,'O que é software?',3),
(58,'O que é hardware?',3),
(59,'Qual linguagem é usada no Android?',3),
(60,'O que é um servidor?',3),
(61,'O que é internet?',3),
(62,'O que é um IP?',3),
(63,'O que é DNS?',3),
(64,'O que é um compilador?',3),
(65,'O que é open source?',3),
(66,'O que é um sistema operativo?',3),
(67,'O que é um browser?',3),
(68,'O que é cloud computing?',3),
(69,'O que é um firewall?',3),
(70,'O que é um banco de dados?',3),
(71,'O que é SQL?',3),
(72,'O que é backend?',3),
(73,'O que é frontend?',3),
(74,'O que é API?',3),
(75,'O que é Git?',3);


-- =====================================
-- RESPOSTAS (4 por pergunta)
-- =====================================

INSERT INTO resposta (resposta, correta, id_pergunta) VALUES

-- GEOGRAFIA
('Nilo',1,16),('Amazonas',0,16),('Tejo',0,16),('Danúbio',0,16),
('China',1,17),('Índia',0,17),('EUA',0,17),('Brasil',0,17),
('Vaticano',1,18),('Mônaco',0,18),('Malta',0,18),('Luxemburgo',0,18),
('Everest',1,19),('K2',0,19),('Alpes',0,19),('Andes',0,19),
('França',1,20),('Itália',0,20),('Espanha',0,20),('Alemanha',0,20),
('Antártida',1,21),('Saara',0,21),('Gobi',0,21),('Atacama',0,21),
('Estados Unidos',1,22),('Canadá',0,22),('Brasil',0,22),('México',0,22),
('Tóquio',1,23),('Pequim',0,23),('Seul',0,23),('Bangkok',0,23),
('Atlântico',1,24),('Pacífico',0,24),('Índico',0,24),('Ártico',0,24),
('Ásia',1,25),('Europa',0,25),('África',0,25),('América',0,25),
('Itália',1,26),('Espanha',0,26),('França',0,26),('Portugal',0,26),
('Madrid',1,27),('Barcelona',0,27),('Valência',0,27),('Sevilha',0,27),
('Berlim',1,28),('Munique',0,28),('Hamburgo',0,28),('Colônia',0,28),
('Roma',1,29),('Milão',0,29),('Nápoles',0,29),('Turim',0,29),
('Estados Unidos',1,30),('Brasil',0,30),('China',0,30),('Índia',0,30),
('Mar Cáspio',1,31),('Superior',0,31),('Baikal',0,31),('Vitória',0,31),
('Brasília',1,32),('Rio',0,32),('São Paulo',0,32),('Salvador',0,32),
('Paris',1,33),('Lyon',0,33),('Marselha',0,33),('Nice',0,33),
('Suécia',1,34),('Indonésia',0,34),('Japão',0,34),('Filipinas',0,34),
('Everest',1,35),('K2',0,35),('Makalu',0,35),('Lhotse',0,35),

-- HISTÓRIA
('Augusto',1,36),('Nero',0,36),('César',0,36),('Trajano',0,36),
('Cristóvão Colombo',1,37),('Cabral',0,37),('Vasco da Gama',0,37),('Magalhães',0,37),
('476',1,38),('1492',0,38),('1789',0,38),('1914',0,38),
('Líder romano',1,39),('Rei',0,39),('Papa',0,39),('Filósofo',0,39),
('Guerra Fria',1,40),('WWI',0,40),('WWII',0,40),('Civil',0,40),
('Imperador do Brasil',1,41),('Rei',0,41),('General',0,41),('Presidente',0,41),
('Líder pacifista',1,42),('Rei',0,42),('Soldado',0,42),('Ditador',0,42),
('Hitler',1,43),('Stalin',0,43),('Churchill',0,43),('Roosevelt',0,43),
('Gregos',1,44),('Romanos',0,44),('Egípcios',0,44),('Maias',0,44),
('Conquistador',1,45),('Rei',0,45),('Filósofo',0,45),('General romano',0,45),
('Portugal',1,46),('Espanha',0,46),('França',0,46),('Inglaterra',0,46),
('Primeiro-ministro inglês',1,47),('Presidente',0,47),('Rei',0,47),('General',0,47),
('Conflito global',1,48),('Guerra local',0,48),('Revolução',0,48),('Crise',0,48),
('Filósofo',1,49),('Rei',0,49),('Soldado',0,49),('Cientista',0,49),
('Incas',1,50),('Maias',0,50),('Astecas',0,50),('Egípcios',0,50),
('Rainha egípcia',1,51),('Princesa',0,51),('Imperatriz',0,51),('Deusa',0,51),
('Romano',1,52),('Otomano',0,52),('Persa',0,52),('Chinês',0,52),
('Neil Armstrong',1,53),('Buzz Aldrin',0,53),('Yuri Gagarin',0,53),('Collins',0,53),
('Imperador francês',1,54),('Rei',0,54),('General',0,54),('Papa',0,54),
('Revolução Francesa',1,55),('WWI',0,55),('WWII',0,55),('Independência',0,55),

-- TECNOLOGIA
('Sequência de instruções',1,56),('Hardware',0,56),('Sistema',0,56),('Programa visual',0,56),
('Programas',1,57),('Peças físicas',0,57),('Rede',0,57),('Sistema',0,57),
('Parte física',1,58),('Software',0,58),('Rede',0,58),('Sistema',0,58),
('Java',1,59),('Python',0,59),('C#',0,59),('PHP',0,59),
('Computador remoto',1,60),('Mouse',0,60),('Monitor',0,60),('Teclado',0,60),
('Rede global',1,61),('PC',0,61),('Software',0,61),('Servidor',0,61),
('Endereço',1,62),('Programa',0,62),('Sistema',0,62),('Hardware',0,62),
('Sistema de nomes',1,63),('IP',0,63),('Rede',0,63),('Servidor',0,63),
('Traduz código',1,64),('Executa',0,64),('Armazena',0,64),('Desenha',0,64),
('Código aberto',1,65),('Pago',0,65),('Privado',0,65),('Fechado',0,65),
('Gerencia hardware',1,66),('Programa',0,66),('Rede',0,66),('App',0,66),
('Navegador',1,67),('Editor',0,67),('Sistema',0,67),('Servidor',0,67),
('Computação na nuvem',1,68),('Hardware',0,68),('Local',0,68),('Offline',0,68),
('Proteção rede',1,69),('Antivírus',0,69),('Sistema',0,69),('App',0,69),
('Armazena dados',1,70),('Executa',0,70),('Desenha',0,70),('Liga PC',0,70),
('Linguagem BD',1,71),('Sistema',0,71),('App',0,71),('Hardware',0,71),
('Servidor lógica',1,72),('Interface',0,72),('Design',0,72),('UI',0,72),
('Interface usuário',1,73),('Servidor',0,73),('Banco',0,73),('Rede',0,73),
('Integra sistemas',1,74),('Programa',0,74),('Rede',0,74),('Hardware',0,74),
('Controle versão',1,75),('Editor',0,75),('IDE',0,75),('Sistema',0,75);