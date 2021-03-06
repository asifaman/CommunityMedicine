USE [CMDB]
GO
/****** Object:  Table [dbo].[SendMedicines]    Script Date: 02/17/2015 20:11:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SendMedicines](
	[SendMedicineId] [int] IDENTITY(1,1) NOT NULL,
	[Quantity] [int] NOT NULL,
	[NewCenterId] [int] NOT NULL,
	[MedicineId] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_dbo.SendMedicines] PRIMARY KEY CLUSTERED 
(
	[SendMedicineId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[SendMedicines] ON
INSERT [dbo].[SendMedicines] ([SendMedicineId], [Quantity], [NewCenterId], [MedicineId]) VALUES (1, 56, 1, N'Paracitamol')
INSERT [dbo].[SendMedicines] ([SendMedicineId], [Quantity], [NewCenterId], [MedicineId]) VALUES (2, 567, 2, N'Pantonix')
INSERT [dbo].[SendMedicines] ([SendMedicineId], [Quantity], [NewCenterId], [MedicineId]) VALUES (3, 56, 0, N'Paracitamol')
SET IDENTITY_INSERT [dbo].[SendMedicines] OFF
/****** Object:  Table [dbo].[NewCenters]    Script Date: 02/17/2015 20:11:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NewCenters](
	[NewCenterId] [int] IDENTITY(1,1) NOT NULL,
	[CenterName] [nvarchar](max) NOT NULL,
	[CenterDistricId] [int] NOT NULL,
	[CenterthanaId] [int] NOT NULL,
	[CenterCode] [int] NOT NULL,
	[Password] [int] NOT NULL,
 CONSTRAINT [PK_dbo.NewCenters] PRIMARY KEY CLUSTERED 
(
	[NewCenterId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[NewCenters] ON
INSERT [dbo].[NewCenters] ([NewCenterId], [CenterName], [CenterDistricId], [CenterthanaId], [CenterCode], [Password]) VALUES (1, N'Mohepur', 2, 4, 3495, 14010)
INSERT [dbo].[NewCenters] ([NewCenterId], [CenterName], [CenterDistricId], [CenterthanaId], [CenterCode], [Password]) VALUES (2, N'Hajipur', 2, 4, 3637, 14025)
INSERT [dbo].[NewCenters] ([NewCenterId], [CenterName], [CenterDistricId], [CenterthanaId], [CenterCode], [Password]) VALUES (3, N'moktarpur', 1, 1, 3708, 14064)
INSERT [dbo].[NewCenters] ([NewCenterId], [CenterName], [CenterDistricId], [CenterthanaId], [CenterCode], [Password]) VALUES (4, N'jatra', 1, 2, 3487, 14035)
SET IDENTITY_INSERT [dbo].[NewCenters] OFF
/****** Object:  Table [dbo].[Medicines]    Script Date: 02/17/2015 20:11:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Medicines](
	[MedicineId] [int] IDENTITY(1,1) NOT NULL,
	[GenericName] [nvarchar](max) NOT NULL,
	[MeasurementUnit] [nvarchar](3) NOT NULL,
	[Power] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_dbo.Medicines] PRIMARY KEY CLUSTERED 
(
	[MedicineId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Medicines] ON
INSERT [dbo].[Medicines] ([MedicineId], [GenericName], [MeasurementUnit], [Power]) VALUES (1, N'Paracitamol', N'500', N'MG')
INSERT [dbo].[Medicines] ([MedicineId], [GenericName], [MeasurementUnit], [Power]) VALUES (2, N'Pantonix', N'500', N'MG')
INSERT [dbo].[Medicines] ([MedicineId], [GenericName], [MeasurementUnit], [Power]) VALUES (3, N'Alartol', N'20', N'MG')
SET IDENTITY_INSERT [dbo].[Medicines] OFF
/****** Object:  Table [dbo].[MeasurementUnits]    Script Date: 02/17/2015 20:11:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MeasurementUnits](
	[MeasurementUnitId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.MeasurementUnits] PRIMARY KEY CLUSTERED 
(
	[MeasurementUnitId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[MeasurementUnits] ON
INSERT [dbo].[MeasurementUnits] ([MeasurementUnitId], [Name]) VALUES (1, N'MG')
INSERT [dbo].[MeasurementUnits] ([MeasurementUnitId], [Name]) VALUES (2, N'ML')
SET IDENTITY_INSERT [dbo].[MeasurementUnits] OFF
/****** Object:  Table [dbo].[Logins]    Script Date: 02/17/2015 20:11:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Logins](
	[LoginId] [nvarchar](128) NOT NULL,
	[CenterCode] [nvarchar](max) NULL,
	[Password] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.Logins] PRIMARY KEY CLUSTERED 
(
	[LoginId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Doses]    Script Date: 02/17/2015 20:11:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Doses](
	[DoseId] [int] IDENTITY(1,1) NOT NULL,
	[DoseName] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.Doses] PRIMARY KEY CLUSTERED 
(
	[DoseId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Doses] ON
INSERT [dbo].[Doses] ([DoseId], [DoseName]) VALUES (1, N'1+0+0')
INSERT [dbo].[Doses] ([DoseId], [DoseName]) VALUES (2, N'1+1+0')
INSERT [dbo].[Doses] ([DoseId], [DoseName]) VALUES (3, N'1+1+1')
INSERT [dbo].[Doses] ([DoseId], [DoseName]) VALUES (4, N'0+1+1')
INSERT [dbo].[Doses] ([DoseId], [DoseName]) VALUES (5, N'0+0+1')
INSERT [dbo].[Doses] ([DoseId], [DoseName]) VALUES (6, N'0+1+0')
INSERT [dbo].[Doses] ([DoseId], [DoseName]) VALUES (7, N'1+1+1+1')
INSERT [dbo].[Doses] ([DoseId], [DoseName]) VALUES (8, N'1+0+1')
SET IDENTITY_INSERT [dbo].[Doses] OFF
/****** Object:  Table [dbo].[DoctorEntries]    Script Date: 02/17/2015 20:11:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DoctorEntries](
	[DoctorEntryId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[Degree] [nvarchar](max) NOT NULL,
	[Specialization] [nvarchar](max) NOT NULL,
	[CenterId] [int] NOT NULL,
 CONSTRAINT [PK_dbo.DoctorEntries] PRIMARY KEY CLUSTERED 
(
	[DoctorEntryId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[DoctorEntries] ON
INSERT [dbo].[DoctorEntries] ([DoctorEntryId], [Name], [Degree], [Specialization], [CenterId]) VALUES (1, N'Dr Jamal', N'MBBS', N'Medicine', 3495)
INSERT [dbo].[DoctorEntries] ([DoctorEntryId], [Name], [Degree], [Specialization], [CenterId]) VALUES (2, N'Dr Jamal', N'MBBS', N'Medicine', 3495)
INSERT [dbo].[DoctorEntries] ([DoctorEntryId], [Name], [Degree], [Specialization], [CenterId]) VALUES (3, N'Dr Kamal Hossan', N'MBBS', N'Medicine', 3495)
INSERT [dbo].[DoctorEntries] ([DoctorEntryId], [Name], [Degree], [Specialization], [CenterId]) VALUES (4, N'Rimi Khanom', N'MBBS', N'Skin', 3637)
SET IDENTITY_INSERT [dbo].[DoctorEntries] OFF
/****** Object:  Table [dbo].[Districts]    Script Date: 02/17/2015 20:11:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Districts](
	[DistrictId] [int] IDENTITY(1,1) NOT NULL,
	[DistrictName] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.Districts] PRIMARY KEY CLUSTERED 
(
	[DistrictId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Districts] ON
INSERT [dbo].[Districts] ([DistrictId], [DistrictName]) VALUES (1, N'Dhaka')
INSERT [dbo].[Districts] ([DistrictId], [DistrictName]) VALUES (2, N'Khulna')
INSERT [dbo].[Districts] ([DistrictId], [DistrictName]) VALUES (3, N'Chittagong')
INSERT [dbo].[Districts] ([DistrictId], [DistrictName]) VALUES (4, N'Barisal')
INSERT [dbo].[Districts] ([DistrictId], [DistrictName]) VALUES (5, N'Rajshahi')
INSERT [dbo].[Districts] ([DistrictId], [DistrictName]) VALUES (6, N'Rangpur')
INSERT [dbo].[Districts] ([DistrictId], [DistrictName]) VALUES (7, N'Sylhet')
SET IDENTITY_INSERT [dbo].[Districts] OFF
/****** Object:  Table [dbo].[Diseases]    Script Date: 02/17/2015 20:11:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Diseases](
	[DiseaseId] [int] IDENTITY(1,1) NOT NULL,
	[DiseaseName] [nvarchar](max) NOT NULL,
	[DiseaseDescription] [nvarchar](max) NOT NULL,
	[TreatmentProcedure] [nvarchar](max) NOT NULL,
	[PreferDrug] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_dbo.Diseases] PRIMARY KEY CLUSTERED 
(
	[DiseaseId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Diseases] ON
INSERT [dbo].[Diseases] ([DiseaseId], [DiseaseName], [DiseaseDescription], [TreatmentProcedure], [PreferDrug]) VALUES (1, N'Fever', N'not good', N'some', N'paracitamol')
INSERT [dbo].[Diseases] ([DiseaseId], [DiseaseName], [DiseaseDescription], [TreatmentProcedure], [PreferDrug]) VALUES (2, N'Alergy', N'not good', N'some', N'Alartol')
INSERT [dbo].[Diseases] ([DiseaseId], [DiseaseName], [DiseaseDescription], [TreatmentProcedure], [PreferDrug]) VALUES (3, N'Dengo', N'not good', N'some', N'paracitamol')
INSERT [dbo].[Diseases] ([DiseaseId], [DiseaseName], [DiseaseDescription], [TreatmentProcedure], [PreferDrug]) VALUES (4, N'Malaria', N'not good', N'some', N'paracitamol')
INSERT [dbo].[Diseases] ([DiseaseId], [DiseaseName], [DiseaseDescription], [TreatmentProcedure], [PreferDrug]) VALUES (5, N'Influenza', N'not good', N'paracitamol', N'Alartol')
SET IDENTITY_INSERT [dbo].[Diseases] OFF
/****** Object:  Table [dbo].[__MigrationHistory]    Script Date: 02/17/2015 20:11:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[__MigrationHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ContextKey] [nvarchar](300) NOT NULL,
	[Model] [varbinary](max) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK_dbo.__MigrationHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC,
	[ContextKey] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
INSERT [dbo].[__MigrationHistory] ([MigrationId], [ContextKey], [Model], [ProductVersion]) VALUES (N'201502151636484_First', N'CommunityMedicine.Migrations.Configuration', 0x1F8B0800000000000400ED5D496FE4B815BE07C87F10744A821ECBCBA56354CDC029B70746DA4B5CEE466E0D5AA2CB4224B122516E5782FCB21CF293E62F0CB5515CB5509B0708FAE222F53E3EF22DDCDE63FFF2DFFFAD7E7A0B03EB15C6898FA2B57D72746C5B307291E747BBB59DE2E71F3EDA3FFDF8FBDFAD3E79E19BF5B5FAEE2CFB8E5046C9DA7EC1787FEE3889FB0243901C85BE1BA3043DE32317850EF090737A7CFC67E7E4C48104C2265896B57A4823EC8730FF417E6E50E4C23D4E4170833C18246539A9D9E6A8D62D0861B2072E5CDB1B148669E4E3C30DF47CD78FE05141635B17810F083F5B183CDB168822840126DC9E7F49E016C728DA6DF7A400048F873D24DF3D832081652FCEEBCFBB76E8F834EB90531356506E9A6014F6043C392B47C811C98DC6D9A62348C6F013196B7CC87A9D8FE3DABEF41308B2BE8B6D9D6F8238FB4E3FCA4725ED074BFAE203550FA245D93FF24D1AE03486EB08A63806C107EB3E7D0A7CF7AFF0F088FE01A375940601CB2A6196D47105A4E83E467B18E3C3037CE63B70EDD996C3933B223DA596498B9E5E47F8ECD4B66E092BE02980542F9851D96214C39F61046380A1770F30863111EBB507F3919598503799FDA81A25FA480CCCB66EC0DB6718EDF0CBDA267FDAD695FF06BDAAA464E44BE4137B2444384EA182D14E8D5FC2C48DFD7DA15073F3F0184380433258A4DC851ED188F979B88FE1338C2FE3743775DB2BA736B83633242CB8D8D40E73E2C50D31E7C2D01229ED8CA698B739922D0A8DDD82577F97F3291AC00B88806D3DC020AF4D5EFC7D314F1DE535DF6A4DB88A51F880828A86D67C7B04F10E920F1E91B27A8BD2D83555C4923D032DCC299755C19C0513FDA38473295FDEE0349A676C5A5D35B8D6D0214A5C69A946892B1D37F3A6C825E221C5F1C1CCA1D6F40BFBD49A1123B7CA93CFA5DC0BAD6EE02E860BB4BBDD4397EC24FC7F816556541B221418F733EF1E9664BA37408B6F0C90E1AE00CDBC2540A3ED078C44FC19EDFCC848C639E5B242CE5930913225D40EFAC9E9C7E9CC754300269FFAEF41927C4771532727D5AC1BB2DB2442CF767B04CE6C6F23602CAB6D0233267AA780F88D4DCB86AA5008CB50072A492F2BFCA24933A9D7B473893BA7F4DD65166392E96B19389BE484077D87F1BB39DCB985DF0BAF6FA4FD947A59F5A76C98E83F473C9701142D2EA3FF45DBE56EB6F7D65B0986BB9D51F45D7D98E1884B8B51371D5B187983260C166059AB613931311C917E2EDBF95B0ACAEF8668490FB36F9B4EC42158DCA9D38B0CB3C3D28A7AE103D38A0DA3435396782EC5FC8A38759A6CEF34CBD9EC85E7C53049266F07ECA6EF4BB5C299A59959B6CF54BF5D9446789803BB7B4A60FC3AD60961CB811231ACE91BC98F96E7BAC118F1CEBCDB44334FC7F2C3D5C97B0482C91BA9960B3FFBAF33F8805B348782D32BAC594E4C2E9204B97EEE20D82BC2FA268D67F653E459CDD76A05D3F44A8E304ED610FE9EAC1A48EB6BFB4F52FFB590F4BAB986AC0787473DB1C535C75D74090388A175E11601501B90B8C093879F8C8BC7973C64511AD9AA00041B149106811F61794DE347AEBF074123EF0255CFF8858C3BDA8E587309F7648D4ED86C94C77006683BC2B0B58DD2CA61544B5ED1121A4C28605C9D1A91C9E33B505D9B7E4960B9AE4D4AC516F527C3DB422C4696D50A5F6B4F512369A084506A990AA2AC6AC128955F0228CBDB38A017A8BEB223EC3D732B947A2C50878128AF6824E2B2BC855A3A8B9370A42F5A11ABCDB902AAAA6AC1600EC52410A6AE05853F2A9080F8EA3655A97774B2BAD475020A635D82D6315110CC47EA3809D1DC5BFD3B659EAAB8E4325A1D3A83A1B52787EF9F6226A31E84D6AD9C2254B72C58399A98DED50DD8EFC9A4CAC4F89625D6B60CF0FD61DB3FE6352C301C375184BE526E694BC482C9FE48A8CDB6EE1EBCF2E30493E53478CADDD5C60BA5CF2A7FA951ADAA15DE25CA92AAD4ADFA3EFBBBDCF0B444DF2AA69612E48AF42B53D9BC8B9017B69AD2CA82AC4100627DA0EC06056918B584DE76C02A16D80AB4A2A2371E17D4AA80E5EABBA3ABC2555974557D77743610954565CB65B4952308585A2B48FA242DB578F5ECAABC3A5F65A6BD4AB46EEAAB216DD011BAB2127443BBE26A4753AA3053F36E24574C10A3884D09D541661A3AADD955771D9CADA9A33B5B71643931C5FDC5DE4F8996325676E13A8EC1326B5D039B6DA2D68E381FBEC80D7A53606413A6AC0CBDF5A08C33E4D829CBBAA38851832C9A58D71DB5BE6D61F174F7B6857E2DA49FA32D8314489D14B2D7020829563FCAF8C23614C5A481F48B9E85A453EC2B47118F12AA837C3474BAA1A5E17CECC86A82039B70D8EB05D9848AF21EEB3B7A4BCEADEE68E9BB11B87800308AE85B403B28412B826EE0155176AC045AE3F89AB0BBCF208B09B33CF018498A6AB44EE2D391EAE556DFF3F302D3855034A17111702C1C57D11D4F3A266BD0A95E6EA28856E37C4451F46E74AA3E911B45A9B4701DB4AA81566BB26C1C0A67B9FAA0B6263C36B24C9E25FAAA95142B264332957D71B16A2B2554FD7F7EACAA35EACF9D238F62014D881D8CA0995CBBE910A2C9B84D4763A45A136A1D2BC6E2D5A53DA6D691EDD46C3A59EA94865E318C7352A383EB725AA3A76D3D28954E6DF421664D7834CE8BC5A28573EEF76990160B420BBBE3E441582C465ED0D7F5AADCEE720E5C0C91520ABEACEB8ECA054BB1905C458F7D771E10C5EDB9F3923E3BF73ADA493E8632BCB2509E1F9B5C81F0414B2A47D79BC3FC565A3CA5E8B9560EA405726032AD943145AAB9A5ACEAE10D90A8094549FF5360F519F0ECD38974092B7E425BA797B1C2A5EBAABC00EDF2DA9270235A7C625B64885E7D2FBB0DDD1E120CC3A3EC83A3ED3F834DE0679308FDE00644FE334C7011B46C9F1E1F7F149E6A7A3FCF263949E27131D5FAB7937871CDFE6A919F0D716B58B5D95B4185E328DA895E41ECBE80F80F2178FBE3888F0F0DC3D53F28340C577E24A80F5EFF877FCC9468C41777A65223E9911DED380EC82F55DC2FCEFB64CC24A327BD12D363E83A8B5C0AF4BB8E3CF8B6B6FF9D939D5BD77FFF56537EB0EE62E2C8CFAD63EB3FE3BD31A1B91B5CEE8D9449A439A22FE59E3A1986A57EBE6418A698F4950FE7880F921869C918AF814CE32351C77976F0231F06E336D6031B55A7E427360667B00E728A6222EB1483DF788DB5FCCB13CB39BB311E94301ACC315F729864F8148F370C73C99A071994667936ECBD8549D6C99A5B9F65DE2E9844E4F27305634CC2D21304ED73B10E0A2B56BC839DB7098AE8B3475C5EE8EF5596CCF79F44DFC4147F1349E86C63707AFF243E4473ADB14CAAFC243215B2E307AD8C46DB770A59EE83B0984CF641387CB6FA0850A32D48D559E72656A5C8391F767EC0E4950F039272C7879E6B743EAA34CD011FD8DF642CCEEA5CEE4140CA7CED61DE028DA51C42DEF5089B07E3DC6A29077CB6DC672177CF249FDB287DBA212D67DA8CE9DF4E86B49C18288AAE771E747191B6B6BD2744245DA877592985189865496B5AC86BDB9B6849A25681E7551D986733A865FED95A65179834972E8D35A460ABE1BB08A0253B5B059C57B5231B646EAB5A133EEAD26E87FC6E754B456D7B131DD3BF558DD0EAF6567AA587ABDA62BFE86027DD32C895F65255CBAD4C9D612E3A90C68470D5DCC4468E299F551825895C8E5320AE9DF9BFA3C8BC92F8BB1A22FB9FA422E8724E9D7E731D3DA36A7E1138AA3E91D65E1878C4E35FC4D87F066E71DD9C24F99B305F4190924F3E854FD0BB8EEE52BC4F31E9320C9F022EFE319BA39ADACF33E5799E5777F95D79324617089B3EE902BC8BFE92FA8147F9BE52ECA93510D9E457EE573359E26CDFBA3B50A45B24BEB3A0032A878FCED98F30DC07042CB98BB6E0159AF0F625819FE10EB8872ADC440FD22E087ED857973ED8C5204C4A8C9A9EFC243AEC856F3FFE0AD1585932426D0000, N'6.1.2-31219')
/****** Object:  Table [dbo].[Treatments]    Script Date: 02/17/2015 20:11:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Treatments](
	[TreatmentId] [int] IDENTITY(1,1) NOT NULL,
	[VoterId] [nvarchar](max) NULL,
	[Name] [nvarchar](max) NULL,
	[Address] [nvarchar](max) NULL,
	[age] [nvarchar](max) NULL,
	[Center] [nvarchar](max) NULL,
	[CenterCode] [nvarchar](max) NULL,
	[Treatmentcount] [int] NOT NULL,
	[Observation] [nvarchar](max) NULL,
	[Date] [nvarchar](max) NULL,
	[DoctorName] [nvarchar](max) NULL,
	[DiseaseName] [nvarchar](max) NULL,
	[MedicineName] [nvarchar](max) NULL,
	[Dose] [nvarchar](max) NULL,
	[Meal] [nvarchar](max) NULL,
	[QuantityGiver] [nvarchar](max) NULL,
	[Note] [nvarchar](max) NULL,
	[District] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.Treatments] PRIMARY KEY CLUSTERED 
(
	[TreatmentId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Treatments] ON
INSERT [dbo].[Treatments] ([TreatmentId], [VoterId], [Name], [Address], [age], [Center], [CenterCode], [Treatmentcount], [Observation], [Date], [DoctorName], [DiseaseName], [MedicineName], [Dose], [Meal], [QuantityGiver], [Note], [District]) VALUES (1, N'5644309456813', N'Rimi Khanom', N'House no: 12. Road no: 14. Dhanmondi, Dhaka', NULL, N'Mohepur', N'3495', 0, N'some', N'2015-02-01', N'1', N'Fever', N'Paracitamol', NULL, NULL, N'34', N'note', N'Khulna')
INSERT [dbo].[Treatments] ([TreatmentId], [VoterId], [Name], [Address], [age], [Center], [CenterCode], [Treatmentcount], [Observation], [Date], [DoctorName], [DiseaseName], [MedicineName], [Dose], [Meal], [QuantityGiver], [Note], [District]) VALUES (2, N'5644309456813', N'Rimi Khanom', N'House no: 12. Road no: 14. Dhanmondi, Dhaka', NULL, N'Mohepur', N'3495', 0, N'some', N'2015-02-01', N'1', N'Dengo', N'Pantonix', NULL, NULL, N'34', N'note', N'Khulna')
INSERT [dbo].[Treatments] ([TreatmentId], [VoterId], [Name], [Address], [age], [Center], [CenterCode], [Treatmentcount], [Observation], [Date], [DoctorName], [DiseaseName], [MedicineName], [Dose], [Meal], [QuantityGiver], [Note], [District]) VALUES (3, N'5644309456813', N'Rimi Khanom', N'House no: 12. Road no: 14. Dhanmondi, Dhaka', NULL, N'Mohepur', N'3495', 0, N'some', N'2015-02-01', N'1', N'Alergy', N'Alartol', NULL, NULL, N'34', N'note', N'Khulna')
INSERT [dbo].[Treatments] ([TreatmentId], [VoterId], [Name], [Address], [age], [Center], [CenterCode], [Treatmentcount], [Observation], [Date], [DoctorName], [DiseaseName], [MedicineName], [Dose], [Meal], [QuantityGiver], [Note], [District]) VALUES (4, N'9509623450915', N'Asif Latif', N'House no: 98. Road no: 14. Katalgonj, Chittagong', NULL, N'Mohepur', N'3495', 0, N'some', N'2015-02-01', N'1', N'Fever', N'data-Meal', NULL, NULL, N'34', N'note', N'Khulna')
INSERT [dbo].[Treatments] ([TreatmentId], [VoterId], [Name], [Address], [age], [Center], [CenterCode], [Treatmentcount], [Observation], [Date], [DoctorName], [DiseaseName], [MedicineName], [Dose], [Meal], [QuantityGiver], [Note], [District]) VALUES (5, N'9509623450915', N'Asif Latif', N'House no: 98. Road no: 14. Katalgonj, Chittagong', NULL, N'Mohepur', N'3495', 0, N'some', N'2015-02-01', N'1', N'Dengo', N'data-Meal', NULL, NULL, N'34', N'note', N'Khulna')
INSERT [dbo].[Treatments] ([TreatmentId], [VoterId], [Name], [Address], [age], [Center], [CenterCode], [Treatmentcount], [Observation], [Date], [DoctorName], [DiseaseName], [MedicineName], [Dose], [Meal], [QuantityGiver], [Note], [District]) VALUES (6, N'9509623450915', N'Asif Latif', N'House no: 98. Road no: 14. Katalgonj, Chittagong', NULL, N'Mohepur', N'3495', 0, N'some', N'2015-02-01', N'1', N'Alergy', N'data-Meal', NULL, NULL, N'34', N'note', N'Khulna')
INSERT [dbo].[Treatments] ([TreatmentId], [VoterId], [Name], [Address], [age], [Center], [CenterCode], [Treatmentcount], [Observation], [Date], [DoctorName], [DiseaseName], [MedicineName], [Dose], [Meal], [QuantityGiver], [Note], [District]) VALUES (7, N'1098789543218', N'Rakib Hasan', N'Vill. Shantinagar. Thana: Katalgonj, Faridpur', NULL, N'Hajipur', N'3637', 0, N'some', N'2015-02-01', N'4', N'Alergy', N'Pantonix', NULL, NULL, N'34', N'note', N'Khulna')
INSERT [dbo].[Treatments] ([TreatmentId], [VoterId], [Name], [Address], [age], [Center], [CenterCode], [Treatmentcount], [Observation], [Date], [DoctorName], [DiseaseName], [MedicineName], [Dose], [Meal], [QuantityGiver], [Note], [District]) VALUES (8, N'1098789543218', N'Rakib Hasan', N'Vill. Shantinagar. Thana: Katalgonj, Faridpur', NULL, N'Hajipur', N'3637', 0, N'some', N'2015-02-01', N'4', N'Fever', N'Alartol', NULL, NULL, N'34', N'note', N'Khulna')
INSERT [dbo].[Treatments] ([TreatmentId], [VoterId], [Name], [Address], [age], [Center], [CenterCode], [Treatmentcount], [Observation], [Date], [DoctorName], [DiseaseName], [MedicineName], [Dose], [Meal], [QuantityGiver], [Note], [District]) VALUES (9, N'1098789543218', N'Rakib Hasan', N'Vill. Shantinagar. Thana: Katalgonj, Faridpur', NULL, N'Hajipur', N'3637', 0, N'some', N'2015-02-01', N'4', N'Dengo', N'Paracitamol', NULL, NULL, N'34', N'note', N'Khulna')
INSERT [dbo].[Treatments] ([TreatmentId], [VoterId], [Name], [Address], [age], [Center], [CenterCode], [Treatmentcount], [Observation], [Date], [DoctorName], [DiseaseName], [MedicineName], [Dose], [Meal], [QuantityGiver], [Note], [District]) VALUES (10, N'5644309456813', N'Rimi Khanom', N'House no: 12. Road no: 14. Dhanmondi, Dhaka', NULL, N'Hajipur', N'3637', 0, N'some', N'2015-02-01', N'4', N'Alergy', N'data-Meal', NULL, NULL, N'34', N'note', N'Khulna')
INSERT [dbo].[Treatments] ([TreatmentId], [VoterId], [Name], [Address], [age], [Center], [CenterCode], [Treatmentcount], [Observation], [Date], [DoctorName], [DiseaseName], [MedicineName], [Dose], [Meal], [QuantityGiver], [Note], [District]) VALUES (11, N'5644309456813', N'Rimi Khanom', N'House no: 12. Road no: 14. Dhanmondi, Dhaka', NULL, N'Hajipur', N'3637', 0, N'some', N'2015-02-01', N'4', N'Fever', N'data-Meal', NULL, NULL, N'34', N'note', N'Khulna')
INSERT [dbo].[Treatments] ([TreatmentId], [VoterId], [Name], [Address], [age], [Center], [CenterCode], [Treatmentcount], [Observation], [Date], [DoctorName], [DiseaseName], [MedicineName], [Dose], [Meal], [QuantityGiver], [Note], [District]) VALUES (12, N'5644309456813', N'Rimi Khanom', N'House no: 12. Road no: 14. Dhanmondi, Dhaka', NULL, N'Hajipur', N'3637', 0, N'some', N'2015-02-01', N'4', N'Dengo', N'data-Meal', NULL, NULL, N'34', N'note', N'Khulna')
INSERT [dbo].[Treatments] ([TreatmentId], [VoterId], [Name], [Address], [age], [Center], [CenterCode], [Treatmentcount], [Observation], [Date], [DoctorName], [DiseaseName], [MedicineName], [Dose], [Meal], [QuantityGiver], [Note], [District]) VALUES (13, N'5644309456813', N'Rimi Khanom', N'House no: 12. Road no: 14. Dhanmondi, Dhaka', NULL, N'moktarpur', N'3708', 0, N'some', N'2015-02-01', NULL, N'Alergy', N'Pantonix', NULL, NULL, N'67', N'note', N'Dhaka')
INSERT [dbo].[Treatments] ([TreatmentId], [VoterId], [Name], [Address], [age], [Center], [CenterCode], [Treatmentcount], [Observation], [Date], [DoctorName], [DiseaseName], [MedicineName], [Dose], [Meal], [QuantityGiver], [Note], [District]) VALUES (14, N'5644309456813', N'Rimi Khanom', N'House no: 12. Road no: 14. Dhanmondi, Dhaka', NULL, N'moktarpur', N'3708', 0, N'some', N'2015-02-01', NULL, N'Dengo', N'Alartol', NULL, NULL, N'67', N'note', N'Dhaka')
INSERT [dbo].[Treatments] ([TreatmentId], [VoterId], [Name], [Address], [age], [Center], [CenterCode], [Treatmentcount], [Observation], [Date], [DoctorName], [DiseaseName], [MedicineName], [Dose], [Meal], [QuantityGiver], [Note], [District]) VALUES (15, NULL, NULL, NULL, NULL, N'Mohepur', N'3495', 0, NULL, NULL, NULL, N'Select Disease', N'Paracitamol', NULL, NULL, NULL, NULL, N'Khulna')
INSERT [dbo].[Treatments] ([TreatmentId], [VoterId], [Name], [Address], [age], [Center], [CenterCode], [Treatmentcount], [Observation], [Date], [DoctorName], [DiseaseName], [MedicineName], [Dose], [Meal], [QuantityGiver], [Note], [District]) VALUES (16, N'1098789543218', N'Rakib Hasan', N'Vill. Shantinagar. Thana: Katalgonj, Faridpur', NULL, N'Mohepur', N'3495', 0, NULL, NULL, NULL, N'Alergy', N'Paracitamol', N'4', NULL, N'45', N'note', N'Khulna')
INSERT [dbo].[Treatments] ([TreatmentId], [VoterId], [Name], [Address], [age], [Center], [CenterCode], [Treatmentcount], [Observation], [Date], [DoctorName], [DiseaseName], [MedicineName], [Dose], [Meal], [QuantityGiver], [Note], [District]) VALUES (17, N'5644309456813', N'Rimi Khanom', N'House no: 12. Road no: 14. Dhanmondi, Dhaka', NULL, N'Mohepur', N'3495', 0, NULL, NULL, NULL, N'Alergy', N'Paracitamol', N'8', NULL, N'34', N'some', N'Khulna')
INSERT [dbo].[Treatments] ([TreatmentId], [VoterId], [Name], [Address], [age], [Center], [CenterCode], [Treatmentcount], [Observation], [Date], [DoctorName], [DiseaseName], [MedicineName], [Dose], [Meal], [QuantityGiver], [Note], [District]) VALUES (18, N'5644309456813', N'Rimi Khanom', N'House no: 12. Road no: 14. Dhanmondi, Dhaka', NULL, N'Mohepur', N'3495', 0, NULL, NULL, NULL, N'Dengo', N'Paracitamol', N'8', NULL, N'34', N'some', N'Khulna')
INSERT [dbo].[Treatments] ([TreatmentId], [VoterId], [Name], [Address], [age], [Center], [CenterCode], [Treatmentcount], [Observation], [Date], [DoctorName], [DiseaseName], [MedicineName], [Dose], [Meal], [QuantityGiver], [Note], [District]) VALUES (19, N'1098789543218', N'Rakib Hasan', N'Vill. Shantinagar. Thana: Katalgonj, Faridpur', NULL, N'Mohepur', N'3495', 0, NULL, NULL, NULL, N'Fever', N'Paracitamol', N'8', NULL, N'56', N'some', N'Khulna')
INSERT [dbo].[Treatments] ([TreatmentId], [VoterId], [Name], [Address], [age], [Center], [CenterCode], [Treatmentcount], [Observation], [Date], [DoctorName], [DiseaseName], [MedicineName], [Dose], [Meal], [QuantityGiver], [Note], [District]) VALUES (20, N'1098789543218', N'Rakib Hasan', N'Vill. Shantinagar. Thana: Katalgonj, Faridpur', NULL, N'Mohepur', N'3495', 0, NULL, NULL, NULL, N'Alergy', N'Paracitamol', N'8', NULL, N'56', N'some', N'Khulna')
INSERT [dbo].[Treatments] ([TreatmentId], [VoterId], [Name], [Address], [age], [Center], [CenterCode], [Treatmentcount], [Observation], [Date], [DoctorName], [DiseaseName], [MedicineName], [Dose], [Meal], [QuantityGiver], [Note], [District]) VALUES (21, N'5644309456813', N'Rimi Khanom', N'House no: 12. Road no: 14. Dhanmondi, Dhaka', NULL, N'Mohepur', N'3495', 0, NULL, NULL, NULL, N'Fever', N'Paracitamol', N'2', NULL, N'56', N'note', N'Khulna')
INSERT [dbo].[Treatments] ([TreatmentId], [VoterId], [Name], [Address], [age], [Center], [CenterCode], [Treatmentcount], [Observation], [Date], [DoctorName], [DiseaseName], [MedicineName], [Dose], [Meal], [QuantityGiver], [Note], [District]) VALUES (22, N'5644309456813', N'Rimi Khanom', N'House no: 12. Road no: 14. Dhanmondi, Dhaka', NULL, N'Mohepur', N'3495', 0, NULL, NULL, NULL, N'Fever', N'data-Meal', N'2', NULL, N'56', N'note', N'Khulna')
INSERT [dbo].[Treatments] ([TreatmentId], [VoterId], [Name], [Address], [age], [Center], [CenterCode], [Treatmentcount], [Observation], [Date], [DoctorName], [DiseaseName], [MedicineName], [Dose], [Meal], [QuantityGiver], [Note], [District]) VALUES (23, N'5644309456813', N'Rimi Khanom', N'House no: 12. Road no: 14. Dhanmondi, Dhaka', NULL, N'Mohepur', N'3495', 0, NULL, NULL, NULL, N'Alergy', N'Paracitamol', N'2', NULL, N'56', N'note', N'Khulna')
INSERT [dbo].[Treatments] ([TreatmentId], [VoterId], [Name], [Address], [age], [Center], [CenterCode], [Treatmentcount], [Observation], [Date], [DoctorName], [DiseaseName], [MedicineName], [Dose], [Meal], [QuantityGiver], [Note], [District]) VALUES (24, N'5644309456813', N'Rimi Khanom', N'House no: 12. Road no: 14. Dhanmondi, Dhaka', NULL, N'Mohepur', N'3495', 0, NULL, NULL, NULL, N'Dengo', N'Paracitamol', N'2', NULL, N'56', N'note', N'Khulna')
INSERT [dbo].[Treatments] ([TreatmentId], [VoterId], [Name], [Address], [age], [Center], [CenterCode], [Treatmentcount], [Observation], [Date], [DoctorName], [DiseaseName], [MedicineName], [Dose], [Meal], [QuantityGiver], [Note], [District]) VALUES (25, N'1098789543218', N'Rakib Hasan', N'Vill. Shantinagar. Thana: Katalgonj, Faridpur', NULL, N'Mohepur', N'3495', 0, N'observation', N'2015-02-01', N'2', N'Malaria', N'Paracitamol', N'2', NULL, N'23', N'note', N'Khulna')
INSERT [dbo].[Treatments] ([TreatmentId], [VoterId], [Name], [Address], [age], [Center], [CenterCode], [Treatmentcount], [Observation], [Date], [DoctorName], [DiseaseName], [MedicineName], [Dose], [Meal], [QuantityGiver], [Note], [District]) VALUES (26, N'1098789543218', N'Rakib Hasan', N'Vill. Shantinagar. Thana: Katalgonj, Faridpur', NULL, N'Mohepur', N'3495', 0, N'observation', N'2015-02-01', N'2', N'Influenza', N'Paracitamol', N'2', NULL, N'23', N'note', N'Khulna')
INSERT [dbo].[Treatments] ([TreatmentId], [VoterId], [Name], [Address], [age], [Center], [CenterCode], [Treatmentcount], [Observation], [Date], [DoctorName], [DiseaseName], [MedicineName], [Dose], [Meal], [QuantityGiver], [Note], [District]) VALUES (27, N'5644309456813', N'Rimi Khanom', N'House no: 12. Road no: 14. Dhanmondi, Dhaka', NULL, N'Mohepur', N'3495', 0, N'observation', N'2015-02-01', N'2', N'Malaria', N'data-Meal', N'2', NULL, N'23', N'note', N'Khulna')
INSERT [dbo].[Treatments] ([TreatmentId], [VoterId], [Name], [Address], [age], [Center], [CenterCode], [Treatmentcount], [Observation], [Date], [DoctorName], [DiseaseName], [MedicineName], [Dose], [Meal], [QuantityGiver], [Note], [District]) VALUES (28, N'5644309456813', N'Rimi Khanom', N'House no: 12. Road no: 14. Dhanmondi, Dhaka', NULL, N'Mohepur', N'3495', 0, N'observation', N'2015-02-01', N'2', N'Influenza', N'data-Meal', N'2', NULL, N'23', N'note', N'Khulna')
INSERT [dbo].[Treatments] ([TreatmentId], [VoterId], [Name], [Address], [age], [Center], [CenterCode], [Treatmentcount], [Observation], [Date], [DoctorName], [DiseaseName], [MedicineName], [Dose], [Meal], [QuantityGiver], [Note], [District]) VALUES (29, N'9509623450915', N'Asif Latif', N'House no: 98. Road no: 14. Katalgonj, Chittagong', NULL, N'Mohepur', N'3495', 0, N'observation', N'2015-02-01', N'2', N'Malaria', N'data-Meal', N'2', NULL, N'23', N'note', N'Khulna')
INSERT [dbo].[Treatments] ([TreatmentId], [VoterId], [Name], [Address], [age], [Center], [CenterCode], [Treatmentcount], [Observation], [Date], [DoctorName], [DiseaseName], [MedicineName], [Dose], [Meal], [QuantityGiver], [Note], [District]) VALUES (30, N'9509623450915', N'Asif Latif', N'House no: 98. Road no: 14. Katalgonj, Chittagong', NULL, N'Mohepur', N'3495', 0, N'observation', N'2015-02-01', N'2', N'Influenza', N'data-Meal', N'2', NULL, N'23', N'note', N'Khulna')
SET IDENTITY_INSERT [dbo].[Treatments] OFF
/****** Object:  Table [dbo].[Thanas]    Script Date: 02/17/2015 20:11:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Thanas](
	[ThanaId] [int] IDENTITY(1,1) NOT NULL,
	[ThanaName] [nvarchar](max) NULL,
	[DistrictId] [int] NOT NULL,
 CONSTRAINT [PK_dbo.Thanas] PRIMARY KEY CLUSTERED 
(
	[ThanaId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Thanas] ON
INSERT [dbo].[Thanas] ([ThanaId], [ThanaName], [DistrictId]) VALUES (1, N'Motijheel', 1)
INSERT [dbo].[Thanas] ([ThanaId], [ThanaName], [DistrictId]) VALUES (2, N'Ramna', 1)
INSERT [dbo].[Thanas] ([ThanaId], [ThanaName], [DistrictId]) VALUES (3, N'Demra', 1)
INSERT [dbo].[Thanas] ([ThanaId], [ThanaName], [DistrictId]) VALUES (4, N'Kalapara', 2)
INSERT [dbo].[Thanas] ([ThanaId], [ThanaName], [DistrictId]) VALUES (5, N'Galachepa', 2)
SET IDENTITY_INSERT [dbo].[Thanas] OFF
/****** Object:  ForeignKey [FK_dbo.Thanas_dbo.Districts_DistrictId]    Script Date: 02/17/2015 20:11:57 ******/
ALTER TABLE [dbo].[Thanas]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Thanas_dbo.Districts_DistrictId] FOREIGN KEY([DistrictId])
REFERENCES [dbo].[Districts] ([DistrictId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Thanas] CHECK CONSTRAINT [FK_dbo.Thanas_dbo.Districts_DistrictId]
GO
