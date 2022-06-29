
/****** Object:  Table [dbo].[Accounts]    Script Date: 29-06-2022 9.25.48 PM ******/

CREATE TABLE [dbo].[Accounts](
	[AccountNumber] [int] NOT NULL,
	[Name] [varchar](100) NOT NULL,
	[BankCode] [varchar](10) NOT NULL,
	[BeneficiaryName] [varchar](100) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[AccountNumber] ASC,
	[BankCode] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]

/****** Object:  Table [dbo].[Bank]    Script Date: 29-06-2022 9.25.48 PM ******/

CREATE TABLE [dbo].[Bank](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Code] [varchar](10) NOT NULL,
	[Name] [varchar](max) NOT NULL,
	[CountryCode] [char](2) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Code] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

/****** Object:  Table [dbo].[Countries]    Script Date: 29-06-2022 9.25.48 PM ******/




CREATE TABLE [dbo].[Countries](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Code] [char](2) NOT NULL,
	[Name] [varchar](max) NULL,
PRIMARY KEY CLUSTERED 
(
	[Code] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

/****** Object:  Table [dbo].[ExchangeRate]    Script Date: 29-06-2022 9.25.48 PM ******/




CREATE TABLE [dbo].[ExchangeRate](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[SourceCountry] [char](2) NULL,
	[DestinationCountry] [char](2) NULL,
	[ExchangeRate] [decimal](18, 3) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]

/****** Object:  Table [dbo].[Fees]    Script Date: 29-06-2022 9.25.48 PM ******/




CREATE TABLE [dbo].[Fees](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[SourceCountry] [char](2) NULL,
	[DestinationCountry] [char](2) NULL,
	[BaseRate] [decimal](16, 6) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]

/****** Object:  Table [dbo].[States]    Script Date: 29-06-2022 9.25.48 PM ******/




CREATE TABLE [dbo].[States](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Code] [char](2) NOT NULL,
	[Name] [varchar](max) NULL,
PRIMARY KEY CLUSTERED 
(
	[Code] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

/****** Object:  Table [dbo].[Transactions]    Script Date: 29-06-2022 9.25.48 PM ******/




CREATE TABLE [dbo].[Transactions](
	[Id] [uniqueidentifier] NOT NULL,
	[SenderFirstName] [varchar](100) NOT NULL,
	[SenderLastName] [varchar](100) NOT NULL,
	[SenderEmail] [varchar](100) NOT NULL,
	[SenderPhone] [char](10) NOT NULL,
	[SenderAddress] [varchar](max) NOT NULL,
	[SenderCountry] [char](2) NOT NULL,
	[SenderCity] [varchar](100) NOT NULL,
	[SendFromState] [char](2) NOT NULL,
	[SenderPostalCode] [varchar](10) NOT NULL,
	[DateOfBirth] [datetime] NOT NULL,
	[ToFirstName] [varchar](100) NOT NULL,
	[ToLastName] [varchar](100) NOT NULL,
	[ToCountry] [char](2) NOT NULL,
	[ToBankAccountName] [varchar](100) NOT NULL,
	[ToBankAccountNumber] [varchar](100) NOT NULL,
	[ToBankName] [varchar](100) NOT NULL,
	[ToBankCode] [varchar](10) NOT NULL,
	[FromAmount] [decimal](18, 2) NOT NULL,
	[ExchangeRate] [decimal](18, 3) NOT NULL,
	[Fees] [decimal](18, 2) NOT NULL,
	[TransactionNumber] [varchar](25) NOT NULL,
	[FromCurrency] [varchar](5) NULL,
	[Status] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[TransactionNumber] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

INSERT [dbo].[Accounts] ([AccountNumber], [Name], [BankCode], [BeneficiaryName]) VALUES (100001, N'Mahesh', N'BOFA', N'John Silva')

INSERT [dbo].[Accounts] ([AccountNumber], [Name], [BankCode], [BeneficiaryName]) VALUES (100002, N'Tyrion Lannister', N'BOFA', N'Tywin Lannister')

INSERT [dbo].[Accounts] ([AccountNumber], [Name], [BankCode], [BeneficiaryName]) VALUES (100003, N'Tywin Lannister', N'BOFA', N'Tyrion Lannister')

INSERT [dbo].[Accounts] ([AccountNumber], [Name], [BankCode], [BeneficiaryName]) VALUES (100004, N'Sansa Stark', N'BOFA', N'Nedd Stark')

INSERT [dbo].[Accounts] ([AccountNumber], [Name], [BankCode], [BeneficiaryName]) VALUES (100005, N'Nedd Stark', N'SBI', N'Sansa Stark')

INSERT [dbo].[Accounts] ([AccountNumber], [Name], [BankCode], [BeneficiaryName]) VALUES (100006, N'Arya Stark', N'SC', N'Robb Stark')

INSERT [dbo].[Accounts] ([AccountNumber], [Name], [BankCode], [BeneficiaryName]) VALUES (100007, N'Robb Stark', N'SBI', N'Arya Stark')

INSERT [dbo].[Accounts] ([AccountNumber], [Name], [BankCode], [BeneficiaryName]) VALUES (100008, N'Jon Snow', N'SBI', N'John Doe')

INSERT [dbo].[Accounts] ([AccountNumber], [Name], [BankCode], [BeneficiaryName]) VALUES (100009, N'kaley', N'CNB', N'Mahesh')

INSERT [dbo].[Accounts] ([AccountNumber], [Name], [BankCode], [BeneficiaryName]) VALUES (100009, N'Krish', N'SBI', N'Shahrukh')

SET IDENTITY_INSERT [dbo].[Bank] ON 

INSERT [dbo].[Bank] ([Id], [Code], [Name], [CountryCode]) VALUES (5, N'BOFA', N'Bank of America', N'US')

INSERT [dbo].[Bank] ([Id], [Code], [Name], [CountryCode]) VALUES (2, N'CNB', N'Canara Bank', N'IN')

INSERT [dbo].[Bank] ([Id], [Code], [Name], [CountryCode]) VALUES (3, N'NB', N'Nordea Bank', N'SE')

INSERT [dbo].[Bank] ([Id], [Code], [Name], [CountryCode]) VALUES (4, N'SB', N'Swedbank', N'SE')

INSERT [dbo].[Bank] ([Id], [Code], [Name], [CountryCode]) VALUES (1, N'SBI', N'State Bank of India', N'IN')

INSERT [dbo].[Bank] ([Id], [Code], [Name], [CountryCode]) VALUES (6, N'SC', N'Standard Chartered', N'US')

SET IDENTITY_INSERT [dbo].[Bank] OFF

SET IDENTITY_INSERT [dbo].[Countries] ON 

INSERT [dbo].[Countries] ([Id], [Code], [Name]) VALUES (6, N'AD', N'Andorra')

INSERT [dbo].[Countries] ([Id], [Code], [Name]) VALUES (238, N'AE', N'United Arab Emirates')

INSERT [dbo].[Countries] ([Id], [Code], [Name]) VALUES (1, N'AF', N'Afghanistan')

INSERT [dbo].[Countries] ([Id], [Code], [Name]) VALUES (10, N'AG', N'Antigua and Barbuda')

INSERT [dbo].[Countries] ([Id], [Code], [Name]) VALUES (8, N'AI', N'Anguilla')

INSERT [dbo].[Countries] ([Id], [Code], [Name]) VALUES (3, N'AL', N'Albania')

INSERT [dbo].[Countries] ([Id], [Code], [Name]) VALUES (12, N'AM', N'Armenia')

INSERT [dbo].[Countries] ([Id], [Code], [Name]) VALUES (159, N'AN', N'Netherlands Antilles')

INSERT [dbo].[Countries] ([Id], [Code], [Name]) VALUES (7, N'AO', N'Anla')

INSERT [dbo].[Countries] ([Id], [Code], [Name]) VALUES (9, N'AQ', N'Antarctica')

INSERT [dbo].[Countries] ([Id], [Code], [Name]) VALUES (11, N'AR', N'Argentina')

INSERT [dbo].[Countries] ([Id], [Code], [Name]) VALUES (5, N'AS', N'American Samoa')

INSERT [dbo].[Countries] ([Id], [Code], [Name]) VALUES (15, N'AT', N'Austria')

INSERT [dbo].[Countries] ([Id], [Code], [Name]) VALUES (14, N'AU', N'Australia')

INSERT [dbo].[Countries] ([Id], [Code], [Name]) VALUES (13, N'AW', N'Aruba')

INSERT [dbo].[Countries] ([Id], [Code], [Name]) VALUES (2, N'AX', N'Aland Islands')

INSERT [dbo].[Countries] ([Id], [Code], [Name]) VALUES (16, N'AZ', N'Azerbaijan')

INSERT [dbo].[Countries] ([Id], [Code], [Name]) VALUES (29, N'BA', N'Bosnia and Herzevina')

INSERT [dbo].[Countries] ([Id], [Code], [Name]) VALUES (20, N'BB', N'Barbados')

INSERT [dbo].[Countries] ([Id], [Code], [Name]) VALUES (19, N'BD', N'Bangladesh')

INSERT [dbo].[Countries] ([Id], [Code], [Name]) VALUES (22, N'BE', N'Belgium')

INSERT [dbo].[Countries] ([Id], [Code], [Name]) VALUES (36, N'BF', N'Burkina Faso')

INSERT [dbo].[Countries] ([Id], [Code], [Name]) VALUES (35, N'BG', N'Bulgaria')

INSERT [dbo].[Countries] ([Id], [Code], [Name]) VALUES (18, N'BH', N'Bahrain')

INSERT [dbo].[Countries] ([Id], [Code], [Name]) VALUES (37, N'BI', N'Burundi')

INSERT [dbo].[Countries] ([Id], [Code], [Name]) VALUES (24, N'BJ', N'Benin')

INSERT [dbo].[Countries] ([Id], [Code], [Name]) VALUES (188, N'BL', N'Saint Barthélemy')

INSERT [dbo].[Countries] ([Id], [Code], [Name]) VALUES (25, N'BM', N'Bermuda')

INSERT [dbo].[Countries] ([Id], [Code], [Name]) VALUES (34, N'BN', N'Brunei Darussalam')

INSERT [dbo].[Countries] ([Id], [Code], [Name]) VALUES (27, N'BO', N'Bolivia')

INSERT [dbo].[Countries] ([Id], [Code], [Name]) VALUES (28, N'BQ', N'Bonaire, Sint Eustatius and Saba')

INSERT [dbo].[Countries] ([Id], [Code], [Name]) VALUES (32, N'BR', N'Brazil')

INSERT [dbo].[Countries] ([Id], [Code], [Name]) VALUES (17, N'BS', N'Bahamas')

INSERT [dbo].[Countries] ([Id], [Code], [Name]) VALUES (26, N'BT', N'Bhutan')

INSERT [dbo].[Countries] ([Id], [Code], [Name]) VALUES (31, N'BV', N'Bouvet Island')

INSERT [dbo].[Countries] ([Id], [Code], [Name]) VALUES (30, N'BW', N'Botswana')

INSERT [dbo].[Countries] ([Id], [Code], [Name]) VALUES (21, N'BY', N'Belarus')

INSERT [dbo].[Countries] ([Id], [Code], [Name]) VALUES (23, N'BZ', N'Belize')

INSERT [dbo].[Countries] ([Id], [Code], [Name]) VALUES (40, N'CA', N'Canada')

INSERT [dbo].[Countries] ([Id], [Code], [Name]) VALUES (48, N'CC', N'Cocos (Keeling) Islands')

INSERT [dbo].[Countries] ([Id], [Code], [Name]) VALUES (52, N'CD', N'Con, The Democratic Republic of')

INSERT [dbo].[Countries] ([Id], [Code], [Name]) VALUES (43, N'CF', N'Central African Republic')

INSERT [dbo].[Countries] ([Id], [Code], [Name]) VALUES (51, N'CG', N'Con')

INSERT [dbo].[Countries] ([Id], [Code], [Name]) VALUES (219, N'CH', N'Switzerland')

INSERT [dbo].[Countries] ([Id], [Code], [Name]) VALUES (55, N'CI', N'Cote d''Ivoire')

INSERT [dbo].[Countries] ([Id], [Code], [Name]) VALUES (53, N'CK', N'Cook Islands')

INSERT [dbo].[Countries] ([Id], [Code], [Name]) VALUES (45, N'CL', N'Chile')

INSERT [dbo].[Countries] ([Id], [Code], [Name]) VALUES (39, N'CM', N'Cameroon')

INSERT [dbo].[Countries] ([Id], [Code], [Name]) VALUES (46, N'CN', N'China')

INSERT [dbo].[Countries] ([Id], [Code], [Name]) VALUES (49, N'CO', N'Colombia')

INSERT [dbo].[Countries] ([Id], [Code], [Name]) VALUES (54, N'CR', N'Costa Rica')

INSERT [dbo].[Countries] ([Id], [Code], [Name]) VALUES (200, N'CS', N'Serbia and Montenegro')

INSERT [dbo].[Countries] ([Id], [Code], [Name]) VALUES (57, N'CU', N'Cuba')

INSERT [dbo].[Countries] ([Id], [Code], [Name]) VALUES (41, N'CV', N'Cape Verde')

INSERT [dbo].[Countries] ([Id], [Code], [Name]) VALUES (58, N'CW', N'Curaçao')

INSERT [dbo].[Countries] ([Id], [Code], [Name]) VALUES (47, N'CX', N'Christmas Island')

INSERT [dbo].[Countries] ([Id], [Code], [Name]) VALUES (59, N'CY', N'Cyprus')

INSERT [dbo].[Countries] ([Id], [Code], [Name]) VALUES (60, N'CZ', N'Czechia')

INSERT [dbo].[Countries] ([Id], [Code], [Name]) VALUES (83, N'DE', N'Germany')

INSERT [dbo].[Countries] ([Id], [Code], [Name]) VALUES (62, N'DJ', N'Djibouti')

INSERT [dbo].[Countries] ([Id], [Code], [Name]) VALUES (61, N'DK', N'Denmark')

INSERT [dbo].[Countries] ([Id], [Code], [Name]) VALUES (63, N'DM', N'Dominica')

INSERT [dbo].[Countries] ([Id], [Code], [Name]) VALUES (64, N'DO', N'Dominican Republic')

INSERT [dbo].[Countries] ([Id], [Code], [Name]) VALUES (4, N'DZ', N'Algeria')

INSERT [dbo].[Countries] ([Id], [Code], [Name]) VALUES (65, N'EC', N'Ecuador')

INSERT [dbo].[Countries] ([Id], [Code], [Name]) VALUES (70, N'EE', N'Estonia')

INSERT [dbo].[Countries] ([Id], [Code], [Name]) VALUES (66, N'EG', N'Egypt')

INSERT [dbo].[Countries] ([Id], [Code], [Name]) VALUES (250, N'EH', N'Western Sahara')

INSERT [dbo].[Countries] ([Id], [Code], [Name]) VALUES (69, N'ER', N'Eritrea')

INSERT [dbo].[Countries] ([Id], [Code], [Name]) VALUES (212, N'ES', N'Spain')

INSERT [dbo].[Countries] ([Id], [Code], [Name]) VALUES (71, N'ET', N'Ethiopia')

INSERT [dbo].[Countries] ([Id], [Code], [Name]) VALUES (75, N'FI', N'Finland')

INSERT [dbo].[Countries] ([Id], [Code], [Name]) VALUES (74, N'FJ', N'Fiji')

INSERT [dbo].[Countries] ([Id], [Code], [Name]) VALUES (72, N'FK', N'Falkland Islands (Malvinas)')

INSERT [dbo].[Countries] ([Id], [Code], [Name]) VALUES (146, N'FM', N'Micronesia, Federated States of')

INSERT [dbo].[Countries] ([Id], [Code], [Name]) VALUES (73, N'FO', N'Faroe Islands')

INSERT [dbo].[Countries] ([Id], [Code], [Name]) VALUES (76, N'FR', N'France')

INSERT [dbo].[Countries] ([Id], [Code], [Name]) VALUES (80, N'GA', N'Gabon')

INSERT [dbo].[Countries] ([Id], [Code], [Name]) VALUES (239, N'GB', N'United Kingdom')

INSERT [dbo].[Countries] ([Id], [Code], [Name]) VALUES (88, N'GD', N'Grenada')

INSERT [dbo].[Countries] ([Id], [Code], [Name]) VALUES (82, N'GE', N'Georgia')

INSERT [dbo].[Countries] ([Id], [Code], [Name]) VALUES (77, N'GF', N'French Guiana')

INSERT [dbo].[Countries] ([Id], [Code], [Name]) VALUES (92, N'GG', N'Guernsey')

INSERT [dbo].[Countries] ([Id], [Code], [Name]) VALUES (84, N'GH', N'Ghana')

INSERT [dbo].[Countries] ([Id], [Code], [Name]) VALUES (85, N'GI', N'Gibraltar')

INSERT [dbo].[Countries] ([Id], [Code], [Name]) VALUES (87, N'GL', N'Greenland')

INSERT [dbo].[Countries] ([Id], [Code], [Name]) VALUES (81, N'GM', N'Gambia')

INSERT [dbo].[Countries] ([Id], [Code], [Name]) VALUES (93, N'GN', N'Guinea')

INSERT [dbo].[Countries] ([Id], [Code], [Name]) VALUES (89, N'GP', N'Guadeloupe')

INSERT [dbo].[Countries] ([Id], [Code], [Name]) VALUES (68, N'GQ', N'Equatorial Guinea')

INSERT [dbo].[Countries] ([Id], [Code], [Name]) VALUES (86, N'GR', N'Greece')

INSERT [dbo].[Countries] ([Id], [Code], [Name]) VALUES (210, N'GS', N'South Georgia & The South Sandwich Islands')

INSERT [dbo].[Countries] ([Id], [Code], [Name]) VALUES (91, N'GT', N'Guatemala')

INSERT [dbo].[Countries] ([Id], [Code], [Name]) VALUES (90, N'GU', N'Guam')

INSERT [dbo].[Countries] ([Id], [Code], [Name]) VALUES (94, N'GW', N'Guinea-Bissau')

INSERT [dbo].[Countries] ([Id], [Code], [Name]) VALUES (95, N'GY', N'Guyana')

INSERT [dbo].[Countries] ([Id], [Code], [Name]) VALUES (100, N'HK', N'Hong Kong')

INSERT [dbo].[Countries] ([Id], [Code], [Name]) VALUES (97, N'HM', N'Heard and Mc Donald Islands')

INSERT [dbo].[Countries] ([Id], [Code], [Name]) VALUES (99, N'HN', N'Honduras')

INSERT [dbo].[Countries] ([Id], [Code], [Name]) VALUES (56, N'HR', N'Croatia')

INSERT [dbo].[Countries] ([Id], [Code], [Name]) VALUES (96, N'HT', N'Haiti')

INSERT [dbo].[Countries] ([Id], [Code], [Name]) VALUES (101, N'HU', N'Hungary')

INSERT [dbo].[Countries] ([Id], [Code], [Name]) VALUES (104, N'ID', N'Indonesia')

INSERT [dbo].[Countries] ([Id], [Code], [Name]) VALUES (107, N'IE', N'Ireland')

INSERT [dbo].[Countries] ([Id], [Code], [Name]) VALUES (109, N'IL', N'Israel')

INSERT [dbo].[Countries] ([Id], [Code], [Name]) VALUES (108, N'IM', N'Isle of Man')

INSERT [dbo].[Countries] ([Id], [Code], [Name]) VALUES (103, N'IN', N'India')

INSERT [dbo].[Countries] ([Id], [Code], [Name]) VALUES (33, N'IO', N'British Indian Ocean Territory')

INSERT [dbo].[Countries] ([Id], [Code], [Name]) VALUES (106, N'IQ', N'Iraq')

INSERT [dbo].[Countries] ([Id], [Code], [Name]) VALUES (105, N'IR', N'Iran, Islamic Republic of')

INSERT [dbo].[Countries] ([Id], [Code], [Name]) VALUES (102, N'IS', N'Iceland')

INSERT [dbo].[Countries] ([Id], [Code], [Name]) VALUES (110, N'IT', N'Italy')

INSERT [dbo].[Countries] ([Id], [Code], [Name]) VALUES (113, N'JE', N'Jersey')

INSERT [dbo].[Countries] ([Id], [Code], [Name]) VALUES (111, N'JM', N'Jamaica')

INSERT [dbo].[Countries] ([Id], [Code], [Name]) VALUES (114, N'JO', N'Jordan')

INSERT [dbo].[Countries] ([Id], [Code], [Name]) VALUES (112, N'JP', N'Japan')

INSERT [dbo].[Countries] ([Id], [Code], [Name]) VALUES (116, N'KE', N'Kenya')

INSERT [dbo].[Countries] ([Id], [Code], [Name]) VALUES (122, N'KG', N'Kyrgyzstan')

INSERT [dbo].[Countries] ([Id], [Code], [Name]) VALUES (38, N'KH', N'Cambodia')

INSERT [dbo].[Countries] ([Id], [Code], [Name]) VALUES (117, N'KI', N'Kiribati')

INSERT [dbo].[Countries] ([Id], [Code], [Name]) VALUES (50, N'KM', N'Comoros')

INSERT [dbo].[Countries] ([Id], [Code], [Name]) VALUES (190, N'KN', N'Saint Kitts & Nevis')

INSERT [dbo].[Countries] ([Id], [Code], [Name]) VALUES (118, N'KP', N'Korea, Democratic People''s Republic of')

INSERT [dbo].[Countries] ([Id], [Code], [Name]) VALUES (119, N'KR', N'Korea, Republic of')

INSERT [dbo].[Countries] ([Id], [Code], [Name]) VALUES (121, N'KW', N'Kuwait')

INSERT [dbo].[Countries] ([Id], [Code], [Name]) VALUES (42, N'KY', N'Cayman Islands')

INSERT [dbo].[Countries] ([Id], [Code], [Name]) VALUES (115, N'KZ', N'Kazakstan')

INSERT [dbo].[Countries] ([Id], [Code], [Name]) VALUES (123, N'LA', N'Lao, People''s Democratic Republic')

INSERT [dbo].[Countries] ([Id], [Code], [Name]) VALUES (125, N'LB', N'Lebanon')

INSERT [dbo].[Countries] ([Id], [Code], [Name]) VALUES (191, N'LC', N'Saint Lucia')

INSERT [dbo].[Countries] ([Id], [Code], [Name]) VALUES (129, N'LI', N'Liechtenstein')

INSERT [dbo].[Countries] ([Id], [Code], [Name]) VALUES (213, N'LK', N'Sri Lanka')

INSERT [dbo].[Countries] ([Id], [Code], [Name]) VALUES (127, N'LR', N'Liberia')

INSERT [dbo].[Countries] ([Id], [Code], [Name]) VALUES (126, N'LS', N'Lesotho')

INSERT [dbo].[Countries] ([Id], [Code], [Name]) VALUES (130, N'LT', N'Lithuania')

INSERT [dbo].[Countries] ([Id], [Code], [Name]) VALUES (131, N'LU', N'Luxembourg')

INSERT [dbo].[Countries] ([Id], [Code], [Name]) VALUES (124, N'LV', N'Latvia')

INSERT [dbo].[Countries] ([Id], [Code], [Name]) VALUES (128, N'LY', N'Libyan Arab Jamahiriya')

INSERT [dbo].[Countries] ([Id], [Code], [Name]) VALUES (152, N'MA', N'Morocco')

INSERT [dbo].[Countries] ([Id], [Code], [Name]) VALUES (148, N'MC', N'Monaco')

INSERT [dbo].[Countries] ([Id], [Code], [Name]) VALUES (147, N'MD', N'Moldova, Republic of')

INSERT [dbo].[Countries] ([Id], [Code], [Name]) VALUES (150, N'ME', N'Montenegro')

INSERT [dbo].[Countries] ([Id], [Code], [Name]) VALUES (192, N'MF', N'Saint Martin')

INSERT [dbo].[Countries] ([Id], [Code], [Name]) VALUES (134, N'MG', N'Madagascar')

INSERT [dbo].[Countries] ([Id], [Code], [Name]) VALUES (140, N'MH', N'Marshall Islands')

INSERT [dbo].[Countries] ([Id], [Code], [Name]) VALUES (133, N'MK', N'Macedonia, The Former Yuslav Republic Of')

INSERT [dbo].[Countries] ([Id], [Code], [Name]) VALUES (138, N'ML', N'Mali')

INSERT [dbo].[Countries] ([Id], [Code], [Name]) VALUES (154, N'MM', N'Myanmar')

INSERT [dbo].[Countries] ([Id], [Code], [Name]) VALUES (149, N'MN', N'Monlia')

INSERT [dbo].[Countries] ([Id], [Code], [Name]) VALUES (132, N'MO', N'Macao')

INSERT [dbo].[Countries] ([Id], [Code], [Name]) VALUES (167, N'MP', N'Northern Mariana Islands')

INSERT [dbo].[Countries] ([Id], [Code], [Name]) VALUES (141, N'MQ', N'Martinique')

INSERT [dbo].[Countries] ([Id], [Code], [Name]) VALUES (142, N'MR', N'Mauritania')

INSERT [dbo].[Countries] ([Id], [Code], [Name]) VALUES (151, N'MS', N'Montserrat')

INSERT [dbo].[Countries] ([Id], [Code], [Name]) VALUES (139, N'MT', N'Malta')

INSERT [dbo].[Countries] ([Id], [Code], [Name]) VALUES (143, N'MU', N'Mauritius')

INSERT [dbo].[Countries] ([Id], [Code], [Name]) VALUES (137, N'MV', N'Maldives')

INSERT [dbo].[Countries] ([Id], [Code], [Name]) VALUES (135, N'MW', N'Malawi')

INSERT [dbo].[Countries] ([Id], [Code], [Name]) VALUES (145, N'MX', N'Mexico')

INSERT [dbo].[Countries] ([Id], [Code], [Name]) VALUES (136, N'MY', N'Malaysia')

INSERT [dbo].[Countries] ([Id], [Code], [Name]) VALUES (153, N'MZ', N'Mozambique')

INSERT [dbo].[Countries] ([Id], [Code], [Name]) VALUES (155, N'NA', N'Namibia')

INSERT [dbo].[Countries] ([Id], [Code], [Name]) VALUES (160, N'NC', N'New Caledonia')

INSERT [dbo].[Countries] ([Id], [Code], [Name]) VALUES (163, N'NE', N'Niger')

INSERT [dbo].[Countries] ([Id], [Code], [Name]) VALUES (166, N'NF', N'Norfolk Island')

INSERT [dbo].[Countries] ([Id], [Code], [Name]) VALUES (164, N'NG', N'Nigeria')

INSERT [dbo].[Countries] ([Id], [Code], [Name]) VALUES (162, N'NI', N'Nicaragua')

INSERT [dbo].[Countries] ([Id], [Code], [Name]) VALUES (158, N'NL', N'Netherlands')

INSERT [dbo].[Countries] ([Id], [Code], [Name]) VALUES (168, N'NO', N'Norway')

INSERT [dbo].[Countries] ([Id], [Code], [Name]) VALUES (157, N'NP', N'Nepal')

INSERT [dbo].[Countries] ([Id], [Code], [Name]) VALUES (156, N'NR', N'Nauru')

INSERT [dbo].[Countries] ([Id], [Code], [Name]) VALUES (165, N'NU', N'Niue')

INSERT [dbo].[Countries] ([Id], [Code], [Name]) VALUES (161, N'NZ', N'New Zealand')

INSERT [dbo].[Countries] ([Id], [Code], [Name]) VALUES (169, N'OM', N'Oman')

INSERT [dbo].[Countries] ([Id], [Code], [Name]) VALUES (173, N'PA', N'Panama')

INSERT [dbo].[Countries] ([Id], [Code], [Name]) VALUES (176, N'PE', N'Peru')

INSERT [dbo].[Countries] ([Id], [Code], [Name]) VALUES (78, N'PF', N'French Polynesia')

INSERT [dbo].[Countries] ([Id], [Code], [Name]) VALUES (174, N'PG', N'Papua New Guinea')

INSERT [dbo].[Countries] ([Id], [Code], [Name]) VALUES (177, N'PH', N'Philippines')

INSERT [dbo].[Countries] ([Id], [Code], [Name]) VALUES (170, N'PK', N'Pakistan')

INSERT [dbo].[Countries] ([Id], [Code], [Name]) VALUES (179, N'PL', N'Poland')

INSERT [dbo].[Countries] ([Id], [Code], [Name]) VALUES (193, N'PM', N'Saint Pierre and Miquelon')

INSERT [dbo].[Countries] ([Id], [Code], [Name]) VALUES (178, N'PN', N'Pitcairn')

INSERT [dbo].[Countries] ([Id], [Code], [Name]) VALUES (181, N'PR', N'Puerto Rico')

INSERT [dbo].[Countries] ([Id], [Code], [Name]) VALUES (172, N'PS', N'Palestinian Territory, Occupied')

INSERT [dbo].[Countries] ([Id], [Code], [Name]) VALUES (180, N'PT', N'Portugal')

INSERT [dbo].[Countries] ([Id], [Code], [Name]) VALUES (171, N'PW', N'Palau')

INSERT [dbo].[Countries] ([Id], [Code], [Name]) VALUES (175, N'PY', N'Paraguay')

INSERT [dbo].[Countries] ([Id], [Code], [Name]) VALUES (182, N'QA', N'Qatar')

INSERT [dbo].[Countries] ([Id], [Code], [Name]) VALUES (184, N'RE', N'Reunion')

INSERT [dbo].[Countries] ([Id], [Code], [Name]) VALUES (185, N'RO', N'Romania')

INSERT [dbo].[Countries] ([Id], [Code], [Name]) VALUES (183, N'RS', N'Republic of Serbia')

INSERT [dbo].[Countries] ([Id], [Code], [Name]) VALUES (186, N'RU', N'Russia Federation')

INSERT [dbo].[Countries] ([Id], [Code], [Name]) VALUES (187, N'RW', N'Rwanda')

INSERT [dbo].[Countries] ([Id], [Code], [Name]) VALUES (198, N'SA', N'Saudi Arabia')

INSERT [dbo].[Countries] ([Id], [Code], [Name]) VALUES (207, N'SB', N'Solomon Islands')

INSERT [dbo].[Countries] ([Id], [Code], [Name]) VALUES (201, N'SC', N'Seychelles')

INSERT [dbo].[Countries] ([Id], [Code], [Name]) VALUES (214, N'SD', N'Sudan')

INSERT [dbo].[Countries] ([Id], [Code], [Name]) VALUES (218, N'SE', N'Sweden')

INSERT [dbo].[Countries] ([Id], [Code], [Name]) VALUES (203, N'SG', N'Singapore')

INSERT [dbo].[Countries] ([Id], [Code], [Name]) VALUES (189, N'SH', N'Saint Helena')

INSERT [dbo].[Countries] ([Id], [Code], [Name]) VALUES (206, N'SI', N'Slovenia')

INSERT [dbo].[Countries] ([Id], [Code], [Name]) VALUES (216, N'SJ', N'Svalbard and Jan Mayen')

INSERT [dbo].[Countries] ([Id], [Code], [Name]) VALUES (205, N'SK', N'Slovakia')

INSERT [dbo].[Countries] ([Id], [Code], [Name]) VALUES (202, N'SL', N'Sierra Leone')

INSERT [dbo].[Countries] ([Id], [Code], [Name]) VALUES (196, N'SM', N'San Marino')

INSERT [dbo].[Countries] ([Id], [Code], [Name]) VALUES (199, N'SN', N'Senegal')

INSERT [dbo].[Countries] ([Id], [Code], [Name]) VALUES (208, N'SO', N'Somalia')

INSERT [dbo].[Countries] ([Id], [Code], [Name]) VALUES (215, N'SR', N'Suriname')

INSERT [dbo].[Countries] ([Id], [Code], [Name]) VALUES (211, N'SS', N'South Sudan')

INSERT [dbo].[Countries] ([Id], [Code], [Name]) VALUES (197, N'ST', N'Sao Tome and Principe')

INSERT [dbo].[Countries] ([Id], [Code], [Name]) VALUES (67, N'SV', N'El Salvador')

INSERT [dbo].[Countries] ([Id], [Code], [Name]) VALUES (204, N'SX', N'Sint Maarten')

INSERT [dbo].[Countries] ([Id], [Code], [Name]) VALUES (220, N'SY', N'Syrian Arab Republic')

INSERT [dbo].[Countries] ([Id], [Code], [Name]) VALUES (217, N'SZ', N'Swaziland')

INSERT [dbo].[Countries] ([Id], [Code], [Name]) VALUES (234, N'TC', N'Turks and Caicos Islands')

INSERT [dbo].[Countries] ([Id], [Code], [Name]) VALUES (44, N'TD', N'Chad')

INSERT [dbo].[Countries] ([Id], [Code], [Name]) VALUES (79, N'TF', N'French Southern Territories')

INSERT [dbo].[Countries] ([Id], [Code], [Name]) VALUES (226, N'TG', N'To')

INSERT [dbo].[Countries] ([Id], [Code], [Name]) VALUES (224, N'TH', N'Thailand')

INSERT [dbo].[Countries] ([Id], [Code], [Name]) VALUES (222, N'TJ', N'Tajikistan')

INSERT [dbo].[Countries] ([Id], [Code], [Name]) VALUES (227, N'TK', N'Tokelau')

INSERT [dbo].[Countries] ([Id], [Code], [Name]) VALUES (225, N'TL', N'Timor-Leste')

INSERT [dbo].[Countries] ([Id], [Code], [Name]) VALUES (233, N'TM', N'Turkmenistan')

INSERT [dbo].[Countries] ([Id], [Code], [Name]) VALUES (230, N'TN', N'Tunisia')

INSERT [dbo].[Countries] ([Id], [Code], [Name]) VALUES (228, N'TO', N'Tonga')

INSERT [dbo].[Countries] ([Id], [Code], [Name]) VALUES (231, N'TR', N'Turkey')

INSERT [dbo].[Countries] ([Id], [Code], [Name]) VALUES (229, N'TT', N'Trinidad and Toba')

INSERT [dbo].[Countries] ([Id], [Code], [Name]) VALUES (235, N'TV', N'Tuvalu')

INSERT [dbo].[Countries] ([Id], [Code], [Name]) VALUES (221, N'TW', N'Taiwan, Province of China')

INSERT [dbo].[Countries] ([Id], [Code], [Name]) VALUES (223, N'TZ', N'Tanzania, United Republic of')

INSERT [dbo].[Countries] ([Id], [Code], [Name]) VALUES (237, N'UA', N'Ukraine')

INSERT [dbo].[Countries] ([Id], [Code], [Name]) VALUES (236, N'UG', N'Uganda')

INSERT [dbo].[Countries] ([Id], [Code], [Name]) VALUES (241, N'UM', N'United States Minor Outlying Islands')

INSERT [dbo].[Countries] ([Id], [Code], [Name]) VALUES (240, N'US', N'United States')

INSERT [dbo].[Countries] ([Id], [Code], [Name]) VALUES (242, N'UY', N'Uruguay')

INSERT [dbo].[Countries] ([Id], [Code], [Name]) VALUES (243, N'UZ', N'Uzbekistan')

INSERT [dbo].[Countries] ([Id], [Code], [Name]) VALUES (98, N'VA', N'Holy See (Vatican City State)')

INSERT [dbo].[Countries] ([Id], [Code], [Name]) VALUES (194, N'VC', N'Saint Vincent and the Grenadines')

INSERT [dbo].[Countries] ([Id], [Code], [Name]) VALUES (245, N'VE', N'Venezuela')

INSERT [dbo].[Countries] ([Id], [Code], [Name]) VALUES (247, N'VG', N'Virgin Islands, British')

INSERT [dbo].[Countries] ([Id], [Code], [Name]) VALUES (248, N'VI', N'Virgin Islands, U.S.')

INSERT [dbo].[Countries] ([Id], [Code], [Name]) VALUES (246, N'VN', N'Vietnam')

INSERT [dbo].[Countries] ([Id], [Code], [Name]) VALUES (244, N'VU', N'Vanuatu')

INSERT [dbo].[Countries] ([Id], [Code], [Name]) VALUES (249, N'WF', N'Wallis and Futuna')

INSERT [dbo].[Countries] ([Id], [Code], [Name]) VALUES (195, N'WS', N'Samoa')

INSERT [dbo].[Countries] ([Id], [Code], [Name]) VALUES (120, N'XK', N'Kosovo (temporary code)')

INSERT [dbo].[Countries] ([Id], [Code], [Name]) VALUES (232, N'XT', N'Turkish Rep N Cyprus (temporary code)')

INSERT [dbo].[Countries] ([Id], [Code], [Name]) VALUES (251, N'YE', N'Yemen')

INSERT [dbo].[Countries] ([Id], [Code], [Name]) VALUES (144, N'YT', N'Mayotte')

INSERT [dbo].[Countries] ([Id], [Code], [Name]) VALUES (209, N'ZA', N'South Africa')

INSERT [dbo].[Countries] ([Id], [Code], [Name]) VALUES (252, N'ZM', N'Zambia')

INSERT [dbo].[Countries] ([Id], [Code], [Name]) VALUES (253, N'ZW', N'Zimbabwe')

SET IDENTITY_INSERT [dbo].[Countries] OFF

SET IDENTITY_INSERT [dbo].[ExchangeRate] ON 

INSERT [dbo].[ExchangeRate] ([Id], [SourceCountry], [DestinationCountry], [ExchangeRate]) VALUES (1, N'US', N'AE', CAST(3.673 AS Decimal(18, 3)))

INSERT [dbo].[ExchangeRate] ([Id], [SourceCountry], [DestinationCountry], [ExchangeRate]) VALUES (2, N'US', N'AF', CAST(89.000 AS Decimal(18, 3)))

INSERT [dbo].[ExchangeRate] ([Id], [SourceCountry], [DestinationCountry], [ExchangeRate]) VALUES (3, N'US', N'AL', CAST(113.275 AS Decimal(18, 3)))

INSERT [dbo].[ExchangeRate] ([Id], [SourceCountry], [DestinationCountry], [ExchangeRate]) VALUES (4, N'US', N'AM', CAST(412.620 AS Decimal(18, 3)))

INSERT [dbo].[ExchangeRate] ([Id], [SourceCountry], [DestinationCountry], [ExchangeRate]) VALUES (5, N'US', N'AN', CAST(1.802 AS Decimal(18, 3)))

INSERT [dbo].[ExchangeRate] ([Id], [SourceCountry], [DestinationCountry], [ExchangeRate]) VALUES (6, N'US', N'AO', CAST(432.118 AS Decimal(18, 3)))

INSERT [dbo].[ExchangeRate] ([Id], [SourceCountry], [DestinationCountry], [ExchangeRate]) VALUES (7, N'US', N'AR', CAST(123.862 AS Decimal(18, 3)))

INSERT [dbo].[ExchangeRate] ([Id], [SourceCountry], [DestinationCountry], [ExchangeRate]) VALUES (8, N'US', N'AU', CAST(1.444 AS Decimal(18, 3)))

INSERT [dbo].[ExchangeRate] ([Id], [SourceCountry], [DestinationCountry], [ExchangeRate]) VALUES (9, N'US', N'AW', CAST(1.801 AS Decimal(18, 3)))

INSERT [dbo].[ExchangeRate] ([Id], [SourceCountry], [DestinationCountry], [ExchangeRate]) VALUES (10, N'US', N'AZ', CAST(1.697 AS Decimal(18, 3)))

INSERT [dbo].[ExchangeRate] ([Id], [SourceCountry], [DestinationCountry], [ExchangeRate]) VALUES (11, N'US', N'BA', CAST(1.859 AS Decimal(18, 3)))

INSERT [dbo].[ExchangeRate] ([Id], [SourceCountry], [DestinationCountry], [ExchangeRate]) VALUES (12, N'US', N'BB', CAST(2.019 AS Decimal(18, 3)))

INSERT [dbo].[ExchangeRate] ([Id], [SourceCountry], [DestinationCountry], [ExchangeRate]) VALUES (13, N'US', N'BD', CAST(92.961 AS Decimal(18, 3)))

INSERT [dbo].[ExchangeRate] ([Id], [SourceCountry], [DestinationCountry], [ExchangeRate]) VALUES (14, N'US', N'BG', CAST(1.852 AS Decimal(18, 3)))

INSERT [dbo].[ExchangeRate] ([Id], [SourceCountry], [DestinationCountry], [ExchangeRate]) VALUES (15, N'US', N'BH', CAST(0.377 AS Decimal(18, 3)))

INSERT [dbo].[ExchangeRate] ([Id], [SourceCountry], [DestinationCountry], [ExchangeRate]) VALUES (16, N'US', N'BI', CAST(2040.000 AS Decimal(18, 3)))

INSERT [dbo].[ExchangeRate] ([Id], [SourceCountry], [DestinationCountry], [ExchangeRate]) VALUES (17, N'US', N'BM', CAST(1.000 AS Decimal(18, 3)))

INSERT [dbo].[ExchangeRate] ([Id], [SourceCountry], [DestinationCountry], [ExchangeRate]) VALUES (18, N'US', N'BN', CAST(1.389 AS Decimal(18, 3)))

INSERT [dbo].[ExchangeRate] ([Id], [SourceCountry], [DestinationCountry], [ExchangeRate]) VALUES (19, N'US', N'BO', CAST(6.884 AS Decimal(18, 3)))

INSERT [dbo].[ExchangeRate] ([Id], [SourceCountry], [DestinationCountry], [ExchangeRate]) VALUES (20, N'US', N'BR', CAST(5.145 AS Decimal(18, 3)))

INSERT [dbo].[ExchangeRate] ([Id], [SourceCountry], [DestinationCountry], [ExchangeRate]) VALUES (21, N'US', N'BS', CAST(1.000 AS Decimal(18, 3)))

INSERT [dbo].[ExchangeRate] ([Id], [SourceCountry], [DestinationCountry], [ExchangeRate]) VALUES (22, N'US', N'BT', CAST(78.195 AS Decimal(18, 3)))

INSERT [dbo].[ExchangeRate] ([Id], [SourceCountry], [DestinationCountry], [ExchangeRate]) VALUES (23, N'US', N'BW', CAST(12.238 AS Decimal(18, 3)))

INSERT [dbo].[ExchangeRate] ([Id], [SourceCountry], [DestinationCountry], [ExchangeRate]) VALUES (24, N'US', N'BY', CAST(3.375 AS Decimal(18, 3)))

INSERT [dbo].[ExchangeRate] ([Id], [SourceCountry], [DestinationCountry], [ExchangeRate]) VALUES (25, N'US', N'BZ', CAST(2.015 AS Decimal(18, 3)))

INSERT [dbo].[ExchangeRate] ([Id], [SourceCountry], [DestinationCountry], [ExchangeRate]) VALUES (26, N'US', N'CA', CAST(1.295 AS Decimal(18, 3)))

INSERT [dbo].[ExchangeRate] ([Id], [SourceCountry], [DestinationCountry], [ExchangeRate]) VALUES (27, N'US', N'CD', CAST(2000.000 AS Decimal(18, 3)))

INSERT [dbo].[ExchangeRate] ([Id], [SourceCountry], [DestinationCountry], [ExchangeRate]) VALUES (28, N'US', N'CH', CAST(0.962 AS Decimal(18, 3)))

INSERT [dbo].[ExchangeRate] ([Id], [SourceCountry], [DestinationCountry], [ExchangeRate]) VALUES (29, N'US', N'CL', CAST(889.550 AS Decimal(18, 3)))

INSERT [dbo].[ExchangeRate] ([Id], [SourceCountry], [DestinationCountry], [ExchangeRate]) VALUES (30, N'US', N'CN', CAST(6.702 AS Decimal(18, 3)))

INSERT [dbo].[ExchangeRate] ([Id], [SourceCountry], [DestinationCountry], [ExchangeRate]) VALUES (31, N'US', N'CO', CAST(4015.260 AS Decimal(18, 3)))

INSERT [dbo].[ExchangeRate] ([Id], [SourceCountry], [DestinationCountry], [ExchangeRate]) VALUES (32, N'US', N'CR', CAST(690.515 AS Decimal(18, 3)))

INSERT [dbo].[ExchangeRate] ([Id], [SourceCountry], [DestinationCountry], [ExchangeRate]) VALUES (33, N'US', N'CU', CAST(26.500 AS Decimal(18, 3)))

INSERT [dbo].[ExchangeRate] ([Id], [SourceCountry], [DestinationCountry], [ExchangeRate]) VALUES (34, N'US', N'CV', CAST(104.795 AS Decimal(18, 3)))

INSERT [dbo].[ExchangeRate] ([Id], [SourceCountry], [DestinationCountry], [ExchangeRate]) VALUES (35, N'US', N'CZ', CAST(23.397 AS Decimal(18, 3)))

INSERT [dbo].[ExchangeRate] ([Id], [SourceCountry], [DestinationCountry], [ExchangeRate]) VALUES (36, N'US', N'DJ', CAST(178.000 AS Decimal(18, 3)))

INSERT [dbo].[ExchangeRate] ([Id], [SourceCountry], [DestinationCountry], [ExchangeRate]) VALUES (37, N'US', N'DK', CAST(7.041 AS Decimal(18, 3)))

INSERT [dbo].[ExchangeRate] ([Id], [SourceCountry], [DestinationCountry], [ExchangeRate]) VALUES (38, N'US', N'DM', CAST(54.650 AS Decimal(18, 3)))

INSERT [dbo].[ExchangeRate] ([Id], [SourceCountry], [DestinationCountry], [ExchangeRate]) VALUES (39, N'US', N'DZ', CAST(145.803 AS Decimal(18, 3)))

INSERT [dbo].[ExchangeRate] ([Id], [SourceCountry], [DestinationCountry], [ExchangeRate]) VALUES (40, N'US', N'EG', CAST(18.764 AS Decimal(18, 3)))

INSERT [dbo].[ExchangeRate] ([Id], [SourceCountry], [DestinationCountry], [ExchangeRate]) VALUES (41, N'US', N'ER', CAST(15.000 AS Decimal(18, 3)))

INSERT [dbo].[ExchangeRate] ([Id], [SourceCountry], [DestinationCountry], [ExchangeRate]) VALUES (42, N'US', N'ET', CAST(51.900 AS Decimal(18, 3)))

INSERT [dbo].[ExchangeRate] ([Id], [SourceCountry], [DestinationCountry], [ExchangeRate]) VALUES (43, N'US', N'FJ', CAST(2.192 AS Decimal(18, 3)))

INSERT [dbo].[ExchangeRate] ([Id], [SourceCountry], [DestinationCountry], [ExchangeRate]) VALUES (44, N'US', N'FK', CAST(0.821 AS Decimal(18, 3)))

INSERT [dbo].[ExchangeRate] ([Id], [SourceCountry], [DestinationCountry], [ExchangeRate]) VALUES (45, N'US', N'GB', CAST(0.815 AS Decimal(18, 3)))

INSERT [dbo].[ExchangeRate] ([Id], [SourceCountry], [DestinationCountry], [ExchangeRate]) VALUES (46, N'US', N'IN', CAST(78.235 AS Decimal(18, 3)))

SET IDENTITY_INSERT [dbo].[ExchangeRate] OFF

SET IDENTITY_INSERT [dbo].[Fees] ON 

INSERT [dbo].[Fees] ([Id], [SourceCountry], [DestinationCountry], [BaseRate]) VALUES (1, N'US', N'AE', CAST(0.000010 AS Decimal(16, 6)))

INSERT [dbo].[Fees] ([Id], [SourceCountry], [DestinationCountry], [BaseRate]) VALUES (2, N'US', N'AF', CAST(0.000020 AS Decimal(16, 6)))

INSERT [dbo].[Fees] ([Id], [SourceCountry], [DestinationCountry], [BaseRate]) VALUES (3, N'US', N'AL', CAST(0.000030 AS Decimal(16, 6)))

INSERT [dbo].[Fees] ([Id], [SourceCountry], [DestinationCountry], [BaseRate]) VALUES (4, N'US', N'AM', CAST(0.000040 AS Decimal(16, 6)))

INSERT [dbo].[Fees] ([Id], [SourceCountry], [DestinationCountry], [BaseRate]) VALUES (5, N'US', N'AN', CAST(0.000050 AS Decimal(16, 6)))

INSERT [dbo].[Fees] ([Id], [SourceCountry], [DestinationCountry], [BaseRate]) VALUES (6, N'US', N'AO', CAST(0.000060 AS Decimal(16, 6)))

INSERT [dbo].[Fees] ([Id], [SourceCountry], [DestinationCountry], [BaseRate]) VALUES (7, N'US', N'AR', CAST(0.000070 AS Decimal(16, 6)))

INSERT [dbo].[Fees] ([Id], [SourceCountry], [DestinationCountry], [BaseRate]) VALUES (8, N'US', N'AU', CAST(0.000080 AS Decimal(16, 6)))

INSERT [dbo].[Fees] ([Id], [SourceCountry], [DestinationCountry], [BaseRate]) VALUES (9, N'US', N'AW', CAST(0.000090 AS Decimal(16, 6)))

INSERT [dbo].[Fees] ([Id], [SourceCountry], [DestinationCountry], [BaseRate]) VALUES (10, N'US', N'AZ', CAST(0.000100 AS Decimal(16, 6)))

INSERT [dbo].[Fees] ([Id], [SourceCountry], [DestinationCountry], [BaseRate]) VALUES (11, N'US', N'BA', CAST(0.000110 AS Decimal(16, 6)))

INSERT [dbo].[Fees] ([Id], [SourceCountry], [DestinationCountry], [BaseRate]) VALUES (12, N'US', N'BB', CAST(0.000120 AS Decimal(16, 6)))

INSERT [dbo].[Fees] ([Id], [SourceCountry], [DestinationCountry], [BaseRate]) VALUES (13, N'US', N'BD', CAST(0.000130 AS Decimal(16, 6)))

INSERT [dbo].[Fees] ([Id], [SourceCountry], [DestinationCountry], [BaseRate]) VALUES (14, N'US', N'BG', CAST(0.000140 AS Decimal(16, 6)))

INSERT [dbo].[Fees] ([Id], [SourceCountry], [DestinationCountry], [BaseRate]) VALUES (15, N'US', N'BH', CAST(0.000150 AS Decimal(16, 6)))

INSERT [dbo].[Fees] ([Id], [SourceCountry], [DestinationCountry], [BaseRate]) VALUES (16, N'US', N'BI', CAST(0.000160 AS Decimal(16, 6)))

INSERT [dbo].[Fees] ([Id], [SourceCountry], [DestinationCountry], [BaseRate]) VALUES (17, N'US', N'BM', CAST(0.000170 AS Decimal(16, 6)))

INSERT [dbo].[Fees] ([Id], [SourceCountry], [DestinationCountry], [BaseRate]) VALUES (18, N'US', N'BN', CAST(0.000180 AS Decimal(16, 6)))

INSERT [dbo].[Fees] ([Id], [SourceCountry], [DestinationCountry], [BaseRate]) VALUES (19, N'US', N'BO', CAST(0.000190 AS Decimal(16, 6)))

INSERT [dbo].[Fees] ([Id], [SourceCountry], [DestinationCountry], [BaseRate]) VALUES (20, N'US', N'BR', CAST(0.000200 AS Decimal(16, 6)))

INSERT [dbo].[Fees] ([Id], [SourceCountry], [DestinationCountry], [BaseRate]) VALUES (21, N'US', N'BS', CAST(0.000210 AS Decimal(16, 6)))

INSERT [dbo].[Fees] ([Id], [SourceCountry], [DestinationCountry], [BaseRate]) VALUES (22, N'US', N'BT', CAST(0.000220 AS Decimal(16, 6)))

INSERT [dbo].[Fees] ([Id], [SourceCountry], [DestinationCountry], [BaseRate]) VALUES (23, N'US', N'BW', CAST(0.000230 AS Decimal(16, 6)))

INSERT [dbo].[Fees] ([Id], [SourceCountry], [DestinationCountry], [BaseRate]) VALUES (24, N'US', N'BY', CAST(0.000240 AS Decimal(16, 6)))

INSERT [dbo].[Fees] ([Id], [SourceCountry], [DestinationCountry], [BaseRate]) VALUES (25, N'US', N'BZ', CAST(0.000250 AS Decimal(16, 6)))

INSERT [dbo].[Fees] ([Id], [SourceCountry], [DestinationCountry], [BaseRate]) VALUES (26, N'US', N'CA', CAST(0.000260 AS Decimal(16, 6)))

INSERT [dbo].[Fees] ([Id], [SourceCountry], [DestinationCountry], [BaseRate]) VALUES (27, N'US', N'CD', CAST(0.000270 AS Decimal(16, 6)))

INSERT [dbo].[Fees] ([Id], [SourceCountry], [DestinationCountry], [BaseRate]) VALUES (28, N'US', N'CH', CAST(0.000280 AS Decimal(16, 6)))

INSERT [dbo].[Fees] ([Id], [SourceCountry], [DestinationCountry], [BaseRate]) VALUES (29, N'US', N'CL', CAST(0.000290 AS Decimal(16, 6)))

INSERT [dbo].[Fees] ([Id], [SourceCountry], [DestinationCountry], [BaseRate]) VALUES (30, N'US', N'CN', CAST(0.000300 AS Decimal(16, 6)))

INSERT [dbo].[Fees] ([Id], [SourceCountry], [DestinationCountry], [BaseRate]) VALUES (31, N'US', N'CO', CAST(0.000310 AS Decimal(16, 6)))

INSERT [dbo].[Fees] ([Id], [SourceCountry], [DestinationCountry], [BaseRate]) VALUES (32, N'US', N'CR', CAST(0.000320 AS Decimal(16, 6)))

INSERT [dbo].[Fees] ([Id], [SourceCountry], [DestinationCountry], [BaseRate]) VALUES (33, N'US', N'CU', CAST(0.000330 AS Decimal(16, 6)))

INSERT [dbo].[Fees] ([Id], [SourceCountry], [DestinationCountry], [BaseRate]) VALUES (34, N'US', N'CV', CAST(0.000340 AS Decimal(16, 6)))

INSERT [dbo].[Fees] ([Id], [SourceCountry], [DestinationCountry], [BaseRate]) VALUES (35, N'US', N'CZ', CAST(0.000350 AS Decimal(16, 6)))

INSERT [dbo].[Fees] ([Id], [SourceCountry], [DestinationCountry], [BaseRate]) VALUES (36, N'US', N'DJ', CAST(0.000360 AS Decimal(16, 6)))

INSERT [dbo].[Fees] ([Id], [SourceCountry], [DestinationCountry], [BaseRate]) VALUES (37, N'US', N'DK', CAST(0.000370 AS Decimal(16, 6)))

INSERT [dbo].[Fees] ([Id], [SourceCountry], [DestinationCountry], [BaseRate]) VALUES (38, N'US', N'DM', CAST(0.000380 AS Decimal(16, 6)))

INSERT [dbo].[Fees] ([Id], [SourceCountry], [DestinationCountry], [BaseRate]) VALUES (39, N'US', N'DZ', CAST(0.000390 AS Decimal(16, 6)))

INSERT [dbo].[Fees] ([Id], [SourceCountry], [DestinationCountry], [BaseRate]) VALUES (40, N'US', N'EG', CAST(0.000400 AS Decimal(16, 6)))

INSERT [dbo].[Fees] ([Id], [SourceCountry], [DestinationCountry], [BaseRate]) VALUES (41, N'US', N'ER', CAST(0.000410 AS Decimal(16, 6)))

INSERT [dbo].[Fees] ([Id], [SourceCountry], [DestinationCountry], [BaseRate]) VALUES (42, N'US', N'ET', CAST(0.000420 AS Decimal(16, 6)))

INSERT [dbo].[Fees] ([Id], [SourceCountry], [DestinationCountry], [BaseRate]) VALUES (43, N'US', N'FJ', CAST(0.000430 AS Decimal(16, 6)))

INSERT [dbo].[Fees] ([Id], [SourceCountry], [DestinationCountry], [BaseRate]) VALUES (44, N'US', N'FK', CAST(0.000440 AS Decimal(16, 6)))

INSERT [dbo].[Fees] ([Id], [SourceCountry], [DestinationCountry], [BaseRate]) VALUES (45, N'US', N'GB', CAST(0.000450 AS Decimal(16, 6)))

INSERT [dbo].[Fees] ([Id], [SourceCountry], [DestinationCountry], [BaseRate]) VALUES (46, N'US', N'IN', CAST(0.000460 AS Decimal(16, 6)))

SET IDENTITY_INSERT [dbo].[Fees] OFF

SET IDENTITY_INSERT [dbo].[States] ON 

INSERT [dbo].[States] ([Id], [Code], [Name]) VALUES (2, N'AK', N'Alaska')

INSERT [dbo].[States] ([Id], [Code], [Name]) VALUES (1, N'AL', N'Alabama')

INSERT [dbo].[States] ([Id], [Code], [Name]) VALUES (4, N'AR', N'Arkansas')

INSERT [dbo].[States] ([Id], [Code], [Name]) VALUES (3, N'AZ', N'Arizona')

INSERT [dbo].[States] ([Id], [Code], [Name]) VALUES (5, N'CA', N'California')

INSERT [dbo].[States] ([Id], [Code], [Name]) VALUES (6, N'CO', N'Colorado')

INSERT [dbo].[States] ([Id], [Code], [Name]) VALUES (7, N'CT', N'Connecticut')

INSERT [dbo].[States] ([Id], [Code], [Name]) VALUES (9, N'DC', N'District of Columbia')

INSERT [dbo].[States] ([Id], [Code], [Name]) VALUES (8, N'DE', N'Delaware')

INSERT [dbo].[States] ([Id], [Code], [Name]) VALUES (10, N'FL', N'Florida')

INSERT [dbo].[States] ([Id], [Code], [Name]) VALUES (11, N'GA', N'Georgia')

INSERT [dbo].[States] ([Id], [Code], [Name]) VALUES (12, N'HI', N'Hawaii')

INSERT [dbo].[States] ([Id], [Code], [Name]) VALUES (16, N'IA', N'Iowa')

INSERT [dbo].[States] ([Id], [Code], [Name]) VALUES (13, N'ID', N'Idaho')

INSERT [dbo].[States] ([Id], [Code], [Name]) VALUES (14, N'IL', N'Illinois')

INSERT [dbo].[States] ([Id], [Code], [Name]) VALUES (15, N'IN', N'Indiana')

INSERT [dbo].[States] ([Id], [Code], [Name]) VALUES (17, N'KS', N'Kansas')

INSERT [dbo].[States] ([Id], [Code], [Name]) VALUES (18, N'KY', N'Kentucky')

INSERT [dbo].[States] ([Id], [Code], [Name]) VALUES (19, N'LA', N'Louisiana')

INSERT [dbo].[States] ([Id], [Code], [Name]) VALUES (22, N'MA', N'Massachusetts')

INSERT [dbo].[States] ([Id], [Code], [Name]) VALUES (21, N'MD', N'Maryland')

INSERT [dbo].[States] ([Id], [Code], [Name]) VALUES (20, N'ME', N'Maine')

INSERT [dbo].[States] ([Id], [Code], [Name]) VALUES (23, N'MI', N'Michigan')

INSERT [dbo].[States] ([Id], [Code], [Name]) VALUES (24, N'MN', N'Minnesota')

INSERT [dbo].[States] ([Id], [Code], [Name]) VALUES (26, N'MO', N'Missouri')

INSERT [dbo].[States] ([Id], [Code], [Name]) VALUES (25, N'MS', N'Mississippi')

INSERT [dbo].[States] ([Id], [Code], [Name]) VALUES (27, N'MT', N'Montana')

INSERT [dbo].[States] ([Id], [Code], [Name]) VALUES (34, N'NC', N'North Carolina')

INSERT [dbo].[States] ([Id], [Code], [Name]) VALUES (35, N'ND', N'North Dakota')

INSERT [dbo].[States] ([Id], [Code], [Name]) VALUES (28, N'NE', N'Nebraska')

INSERT [dbo].[States] ([Id], [Code], [Name]) VALUES (30, N'NH', N'New Hampshire')

INSERT [dbo].[States] ([Id], [Code], [Name]) VALUES (31, N'NJ', N'New Jersey')

INSERT [dbo].[States] ([Id], [Code], [Name]) VALUES (32, N'NM', N'New Mexico')

INSERT [dbo].[States] ([Id], [Code], [Name]) VALUES (29, N'NV', N'Nevada')

INSERT [dbo].[States] ([Id], [Code], [Name]) VALUES (33, N'NY', N'New York')

INSERT [dbo].[States] ([Id], [Code], [Name]) VALUES (36, N'OH', N'Ohio')

INSERT [dbo].[States] ([Id], [Code], [Name]) VALUES (37, N'OK', N'Oklahoma')

INSERT [dbo].[States] ([Id], [Code], [Name]) VALUES (38, N'OR', N'Oren')

INSERT [dbo].[States] ([Id], [Code], [Name]) VALUES (39, N'PA', N'Pennsylvania')

INSERT [dbo].[States] ([Id], [Code], [Name]) VALUES (40, N'RI', N'Rhode Island')

INSERT [dbo].[States] ([Id], [Code], [Name]) VALUES (41, N'SC', N'South Carolina')

INSERT [dbo].[States] ([Id], [Code], [Name]) VALUES (42, N'SD', N'South Dakota')

INSERT [dbo].[States] ([Id], [Code], [Name]) VALUES (43, N'TN', N'Tennessee')

INSERT [dbo].[States] ([Id], [Code], [Name]) VALUES (44, N'TX', N'Texas')

INSERT [dbo].[States] ([Id], [Code], [Name]) VALUES (45, N'UT', N'Utah')

INSERT [dbo].[States] ([Id], [Code], [Name]) VALUES (47, N'VA', N'Virginia')

INSERT [dbo].[States] ([Id], [Code], [Name]) VALUES (46, N'VT', N'Vermont')

INSERT [dbo].[States] ([Id], [Code], [Name]) VALUES (48, N'WA', N'Washington')

INSERT [dbo].[States] ([Id], [Code], [Name]) VALUES (50, N'WI', N'Wisconsin')

INSERT [dbo].[States] ([Id], [Code], [Name]) VALUES (49, N'WV', N'West Virginia')

INSERT [dbo].[States] ([Id], [Code], [Name]) VALUES (51, N'WY', N'Wyoming')

SET IDENTITY_INSERT [dbo].[States] OFF

INSERT [dbo].[Transactions] ([Id], [SenderFirstName], [SenderLastName], [SenderEmail], [SenderPhone], [SenderAddress], [SenderCountry], [SenderCity], [SendFromState], [SenderPostalCode], [DateOfBirth], [ToFirstName], [ToLastName], [ToCountry], [ToBankAccountName], [ToBankAccountNumber], [ToBankName], [ToBankCode], [FromAmount], [ExchangeRate], [Fees], [TransactionNumber], [FromCurrency], [Status]) VALUES (N'b2e3b006-0267-42b3-b2d4-bac4ba451f1c', N'Mahesh', N'Patkar', N'maheshpatkar@gmail.com', N'9768764964', N'Mumbai', N'IN', N'Mumbai', N'MH', N'400101', CAST(N'2022-06-23T08:55:09.387' AS DateTime), N'Shridevi', N'Patkar', N'SE', N'Shridevi Patkar', N'12345', N'HSBC', N'HB', CAST(10000.00 AS Decimal(18, 2)), CAST(1.500 AS Decimal(18, 3)), CAST(100.00 AS Decimal(18, 2)), N'1234567', N'INR', 200)

INSERT [dbo].[Transactions] ([Id], [SenderFirstName], [SenderLastName], [SenderEmail], [SenderPhone], [SenderAddress], [SenderCountry], [SenderCity], [SendFromState], [SenderPostalCode], [DateOfBirth], [ToFirstName], [ToLastName], [ToCountry], [ToBankAccountName], [ToBankAccountNumber], [ToBankName], [ToBankCode], [FromAmount], [ExchangeRate], [Fees], [TransactionNumber], [FromCurrency], [Status]) VALUES (N'04b15696-9dd0-4560-aa6b-0df9613ab2a5', N'Mahesh', N'Patkar', N'maheshpatkar@gmail.com', N'9768764964', N'Mumbai', N'IN', N'Mumbai', N'MH', N'400101', CAST(N'2022-06-23T08:55:09.387' AS DateTime), N'Shridevi', N'Patkar', N'SE', N'Shridevi Patkar', N'12345', N'HSBC', N'HB', CAST(10000.00 AS Decimal(18, 2)), CAST(1.500 AS Decimal(18, 3)), CAST(100.00 AS Decimal(18, 2)), N'12345673', N'INR', 200)

INSERT [dbo].[Transactions] ([Id], [SenderFirstName], [SenderLastName], [SenderEmail], [SenderPhone], [SenderAddress], [SenderCountry], [SenderCity], [SendFromState], [SenderPostalCode], [DateOfBirth], [ToFirstName], [ToLastName], [ToCountry], [ToBankAccountName], [ToBankAccountNumber], [ToBankName], [ToBankCode], [FromAmount], [ExchangeRate], [Fees], [TransactionNumber], [FromCurrency], [Status]) VALUES (N'11a3a4e6-46bc-4967-832d-12f51defc3f1', N'Mahesh', N'Patkar', N'maheshpatkar@gmail.com', N'9768764964', N'Mumbai', N'IN', N'Mumbai', N'MH', N'400101', CAST(N'2022-06-23T08:55:09.387' AS DateTime), N'Shridevi', N'Patkar', N'SE', N'Shridevi Patkar', N'12345', N'HSBC', N'HB', CAST(10000.00 AS Decimal(18, 2)), CAST(1.500 AS Decimal(18, 3)), CAST(100.00 AS Decimal(18, 2)), N'123456736', N'INR', 200)

ALTER TABLE [dbo].[Transactions] ADD  DEFAULT (newid()) FOR [Id]

ALTER TABLE [dbo].[Accounts]  WITH CHECK ADD FOREIGN KEY([BankCode])
REFERENCES [dbo].[Bank] ([Code])

ALTER TABLE [dbo].[Bank]  WITH CHECK ADD FOREIGN KEY([CountryCode])
REFERENCES [dbo].[Countries] ([Code])

ALTER TABLE [dbo].[ExchangeRate]  WITH CHECK ADD FOREIGN KEY([DestinationCountry])
REFERENCES [dbo].[Countries] ([Code])

ALTER TABLE [dbo].[ExchangeRate]  WITH CHECK ADD FOREIGN KEY([SourceCountry])
REFERENCES [dbo].[Countries] ([Code])

ALTER TABLE [dbo].[Fees]  WITH CHECK ADD FOREIGN KEY([DestinationCountry])
REFERENCES [dbo].[Countries] ([Code])

ALTER TABLE [dbo].[Fees]  WITH CHECK ADD FOREIGN KEY([SourceCountry])
REFERENCES [dbo].[Countries] ([Code])

ALTER TABLE [dbo].[Transactions]  WITH CHECK ADD FOREIGN KEY([SenderCountry])
REFERENCES [dbo].[Countries] ([Code])

ALTER TABLE [dbo].[Transactions]  WITH CHECK ADD FOREIGN KEY([ToCountry])
REFERENCES [dbo].[Countries] ([Code])

