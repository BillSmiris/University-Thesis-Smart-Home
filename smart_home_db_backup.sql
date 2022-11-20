PGDMP         &                z         	   smarthome    13.2    13.2 -    �           0    0    ENCODING    ENCODING        SET client_encoding = 'UTF8';
                      false            �           0    0 
   STDSTRINGS 
   STDSTRINGS     (   SET standard_conforming_strings = 'on';
                      false            �           0    0 
   SEARCHPATH 
   SEARCHPATH     8   SELECT pg_catalog.set_config('search_path', '', false);
                      false            �           1262    16394 	   smarthome    DATABASE     m   CREATE DATABASE smarthome WITH TEMPLATE = template0 ENCODING = 'UTF8' LOCALE = 'English_United States.1252';
    DROP DATABASE smarthome;
                postgres    false            �            1259    24698    AspNetRoleClaims    TABLE     �   CREATE TABLE public."AspNetRoleClaims" (
    "Id" integer NOT NULL,
    "RoleId" text NOT NULL,
    "ClaimType" text,
    "ClaimValue" text
);
 &   DROP TABLE public."AspNetRoleClaims";
       public         heap    postgres    false            �            1259    24696    AspNetRoleClaims_Id_seq    SEQUENCE     �   ALTER TABLE public."AspNetRoleClaims" ALTER COLUMN "Id" ADD GENERATED BY DEFAULT AS IDENTITY (
    SEQUENCE NAME public."AspNetRoleClaims_Id_seq"
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1
);
            public          postgres    false    204            �            1259    24680    AspNetRoles    TABLE     �   CREATE TABLE public."AspNetRoles" (
    "Id" text NOT NULL,
    "Name" character varying(256),
    "NormalizedName" character varying(256),
    "ConcurrencyStamp" text
);
 !   DROP TABLE public."AspNetRoles";
       public         heap    postgres    false            �            1259    24713    AspNetUserClaims    TABLE     �   CREATE TABLE public."AspNetUserClaims" (
    "Id" integer NOT NULL,
    "UserId" text NOT NULL,
    "ClaimType" text,
    "ClaimValue" text
);
 &   DROP TABLE public."AspNetUserClaims";
       public         heap    postgres    false            �            1259    24711    AspNetUserClaims_Id_seq    SEQUENCE     �   ALTER TABLE public."AspNetUserClaims" ALTER COLUMN "Id" ADD GENERATED BY DEFAULT AS IDENTITY (
    SEQUENCE NAME public."AspNetUserClaims_Id_seq"
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1
);
            public          postgres    false    206            �            1259    24726    AspNetUserLogins    TABLE     �   CREATE TABLE public."AspNetUserLogins" (
    "LoginProvider" text NOT NULL,
    "ProviderKey" text NOT NULL,
    "ProviderDisplayName" text,
    "UserId" text NOT NULL
);
 &   DROP TABLE public."AspNetUserLogins";
       public         heap    postgres    false            �            1259    24739    AspNetUserRoles    TABLE     b   CREATE TABLE public."AspNetUserRoles" (
    "UserId" text NOT NULL,
    "RoleId" text NOT NULL
);
 %   DROP TABLE public."AspNetUserRoles";
       public         heap    postgres    false            �            1259    24757    AspNetUserTokens    TABLE     �   CREATE TABLE public."AspNetUserTokens" (
    "UserId" text NOT NULL,
    "LoginProvider" text NOT NULL,
    "Name" text NOT NULL,
    "Value" text
);
 &   DROP TABLE public."AspNetUserTokens";
       public         heap    postgres    false            �            1259    24688    AspNetUsers    TABLE     I  CREATE TABLE public."AspNetUsers" (
    "Id" text NOT NULL,
    "UserName" character varying(256),
    "NormalizedUserName" character varying(256),
    "Email" character varying(256),
    "NormalizedEmail" character varying(256),
    "EmailConfirmed" boolean NOT NULL,
    "PasswordHash" text,
    "SecurityStamp" text,
    "ConcurrencyStamp" text,
    "PhoneNumber" text,
    "PhoneNumberConfirmed" boolean NOT NULL,
    "TwoFactorEnabled" boolean NOT NULL,
    "LockoutEnd" timestamp with time zone,
    "LockoutEnabled" boolean NOT NULL,
    "AccessFailedCount" integer NOT NULL
);
 !   DROP TABLE public."AspNetUsers";
       public         heap    postgres    false            �            1259    24675    __EFMigrationsHistory    TABLE     �   CREATE TABLE public."__EFMigrationsHistory" (
    "MigrationId" character varying(150) NOT NULL,
    "ProductVersion" character varying(32) NOT NULL
);
 +   DROP TABLE public."__EFMigrationsHistory";
       public         heap    postgres    false            �          0    24698    AspNetRoleClaims 
   TABLE DATA           W   COPY public."AspNetRoleClaims" ("Id", "RoleId", "ClaimType", "ClaimValue") FROM stdin;
    public          postgres    false    204   �:       �          0    24680    AspNetRoles 
   TABLE DATA           [   COPY public."AspNetRoles" ("Id", "Name", "NormalizedName", "ConcurrencyStamp") FROM stdin;
    public          postgres    false    201   �:       �          0    24713    AspNetUserClaims 
   TABLE DATA           W   COPY public."AspNetUserClaims" ("Id", "UserId", "ClaimType", "ClaimValue") FROM stdin;
    public          postgres    false    206   �;       �          0    24726    AspNetUserLogins 
   TABLE DATA           m   COPY public."AspNetUserLogins" ("LoginProvider", "ProviderKey", "ProviderDisplayName", "UserId") FROM stdin;
    public          postgres    false    207   �;       �          0    24739    AspNetUserRoles 
   TABLE DATA           ?   COPY public."AspNetUserRoles" ("UserId", "RoleId") FROM stdin;
    public          postgres    false    208   �;       �          0    24757    AspNetUserTokens 
   TABLE DATA           X   COPY public."AspNetUserTokens" ("UserId", "LoginProvider", "Name", "Value") FROM stdin;
    public          postgres    false    209   ><       �          0    24688    AspNetUsers 
   TABLE DATA           "  COPY public."AspNetUsers" ("Id", "UserName", "NormalizedUserName", "Email", "NormalizedEmail", "EmailConfirmed", "PasswordHash", "SecurityStamp", "ConcurrencyStamp", "PhoneNumber", "PhoneNumberConfirmed", "TwoFactorEnabled", "LockoutEnd", "LockoutEnabled", "AccessFailedCount") FROM stdin;
    public          postgres    false    202   [<       �          0    24675    __EFMigrationsHistory 
   TABLE DATA           R   COPY public."__EFMigrationsHistory" ("MigrationId", "ProductVersion") FROM stdin;
    public          postgres    false    200   D=       �           0    0    AspNetRoleClaims_Id_seq    SEQUENCE SET     H   SELECT pg_catalog.setval('public."AspNetRoleClaims_Id_seq"', 1, false);
          public          postgres    false    203            �           0    0    AspNetUserClaims_Id_seq    SEQUENCE SET     H   SELECT pg_catalog.setval('public."AspNetUserClaims_Id_seq"', 1, false);
          public          postgres    false    205            R           2606    24705 $   AspNetRoleClaims PK_AspNetRoleClaims 
   CONSTRAINT     h   ALTER TABLE ONLY public."AspNetRoleClaims"
    ADD CONSTRAINT "PK_AspNetRoleClaims" PRIMARY KEY ("Id");
 R   ALTER TABLE ONLY public."AspNetRoleClaims" DROP CONSTRAINT "PK_AspNetRoleClaims";
       public            postgres    false    204            J           2606    24687    AspNetRoles PK_AspNetRoles 
   CONSTRAINT     ^   ALTER TABLE ONLY public."AspNetRoles"
    ADD CONSTRAINT "PK_AspNetRoles" PRIMARY KEY ("Id");
 H   ALTER TABLE ONLY public."AspNetRoles" DROP CONSTRAINT "PK_AspNetRoles";
       public            postgres    false    201            U           2606    24720 $   AspNetUserClaims PK_AspNetUserClaims 
   CONSTRAINT     h   ALTER TABLE ONLY public."AspNetUserClaims"
    ADD CONSTRAINT "PK_AspNetUserClaims" PRIMARY KEY ("Id");
 R   ALTER TABLE ONLY public."AspNetUserClaims" DROP CONSTRAINT "PK_AspNetUserClaims";
       public            postgres    false    206            X           2606    24733 $   AspNetUserLogins PK_AspNetUserLogins 
   CONSTRAINT     �   ALTER TABLE ONLY public."AspNetUserLogins"
    ADD CONSTRAINT "PK_AspNetUserLogins" PRIMARY KEY ("LoginProvider", "ProviderKey");
 R   ALTER TABLE ONLY public."AspNetUserLogins" DROP CONSTRAINT "PK_AspNetUserLogins";
       public            postgres    false    207    207            [           2606    24746 "   AspNetUserRoles PK_AspNetUserRoles 
   CONSTRAINT     t   ALTER TABLE ONLY public."AspNetUserRoles"
    ADD CONSTRAINT "PK_AspNetUserRoles" PRIMARY KEY ("UserId", "RoleId");
 P   ALTER TABLE ONLY public."AspNetUserRoles" DROP CONSTRAINT "PK_AspNetUserRoles";
       public            postgres    false    208    208            ]           2606    24764 $   AspNetUserTokens PK_AspNetUserTokens 
   CONSTRAINT     �   ALTER TABLE ONLY public."AspNetUserTokens"
    ADD CONSTRAINT "PK_AspNetUserTokens" PRIMARY KEY ("UserId", "LoginProvider", "Name");
 R   ALTER TABLE ONLY public."AspNetUserTokens" DROP CONSTRAINT "PK_AspNetUserTokens";
       public            postgres    false    209    209    209            N           2606    24695    AspNetUsers PK_AspNetUsers 
   CONSTRAINT     ^   ALTER TABLE ONLY public."AspNetUsers"
    ADD CONSTRAINT "PK_AspNetUsers" PRIMARY KEY ("Id");
 H   ALTER TABLE ONLY public."AspNetUsers" DROP CONSTRAINT "PK_AspNetUsers";
       public            postgres    false    202            H           2606    24679 .   __EFMigrationsHistory PK___EFMigrationsHistory 
   CONSTRAINT     {   ALTER TABLE ONLY public."__EFMigrationsHistory"
    ADD CONSTRAINT "PK___EFMigrationsHistory" PRIMARY KEY ("MigrationId");
 \   ALTER TABLE ONLY public."__EFMigrationsHistory" DROP CONSTRAINT "PK___EFMigrationsHistory";
       public            postgres    false    200            L           1259    24775 
   EmailIndex    INDEX     S   CREATE INDEX "EmailIndex" ON public."AspNetUsers" USING btree ("NormalizedEmail");
     DROP INDEX public."EmailIndex";
       public            postgres    false    202            P           1259    24770    IX_AspNetRoleClaims_RoleId    INDEX     _   CREATE INDEX "IX_AspNetRoleClaims_RoleId" ON public."AspNetRoleClaims" USING btree ("RoleId");
 0   DROP INDEX public."IX_AspNetRoleClaims_RoleId";
       public            postgres    false    204            S           1259    24772    IX_AspNetUserClaims_UserId    INDEX     _   CREATE INDEX "IX_AspNetUserClaims_UserId" ON public."AspNetUserClaims" USING btree ("UserId");
 0   DROP INDEX public."IX_AspNetUserClaims_UserId";
       public            postgres    false    206            V           1259    24773    IX_AspNetUserLogins_UserId    INDEX     _   CREATE INDEX "IX_AspNetUserLogins_UserId" ON public."AspNetUserLogins" USING btree ("UserId");
 0   DROP INDEX public."IX_AspNetUserLogins_UserId";
       public            postgres    false    207            Y           1259    24774    IX_AspNetUserRoles_RoleId    INDEX     ]   CREATE INDEX "IX_AspNetUserRoles_RoleId" ON public."AspNetUserRoles" USING btree ("RoleId");
 /   DROP INDEX public."IX_AspNetUserRoles_RoleId";
       public            postgres    false    208            K           1259    24771    RoleNameIndex    INDEX     \   CREATE UNIQUE INDEX "RoleNameIndex" ON public."AspNetRoles" USING btree ("NormalizedName");
 #   DROP INDEX public."RoleNameIndex";
       public            postgres    false    201            O           1259    24776    UserNameIndex    INDEX     `   CREATE UNIQUE INDEX "UserNameIndex" ON public."AspNetUsers" USING btree ("NormalizedUserName");
 #   DROP INDEX public."UserNameIndex";
       public            postgres    false    202            ^           2606    24706 7   AspNetRoleClaims FK_AspNetRoleClaims_AspNetRoles_RoleId    FK CONSTRAINT     �   ALTER TABLE ONLY public."AspNetRoleClaims"
    ADD CONSTRAINT "FK_AspNetRoleClaims_AspNetRoles_RoleId" FOREIGN KEY ("RoleId") REFERENCES public."AspNetRoles"("Id") ON DELETE CASCADE;
 e   ALTER TABLE ONLY public."AspNetRoleClaims" DROP CONSTRAINT "FK_AspNetRoleClaims_AspNetRoles_RoleId";
       public          postgres    false    204    201    2890            _           2606    24721 7   AspNetUserClaims FK_AspNetUserClaims_AspNetUsers_UserId    FK CONSTRAINT     �   ALTER TABLE ONLY public."AspNetUserClaims"
    ADD CONSTRAINT "FK_AspNetUserClaims_AspNetUsers_UserId" FOREIGN KEY ("UserId") REFERENCES public."AspNetUsers"("Id") ON DELETE CASCADE;
 e   ALTER TABLE ONLY public."AspNetUserClaims" DROP CONSTRAINT "FK_AspNetUserClaims_AspNetUsers_UserId";
       public          postgres    false    206    2894    202            `           2606    24734 7   AspNetUserLogins FK_AspNetUserLogins_AspNetUsers_UserId    FK CONSTRAINT     �   ALTER TABLE ONLY public."AspNetUserLogins"
    ADD CONSTRAINT "FK_AspNetUserLogins_AspNetUsers_UserId" FOREIGN KEY ("UserId") REFERENCES public."AspNetUsers"("Id") ON DELETE CASCADE;
 e   ALTER TABLE ONLY public."AspNetUserLogins" DROP CONSTRAINT "FK_AspNetUserLogins_AspNetUsers_UserId";
       public          postgres    false    202    2894    207            a           2606    24747 5   AspNetUserRoles FK_AspNetUserRoles_AspNetRoles_RoleId    FK CONSTRAINT     �   ALTER TABLE ONLY public."AspNetUserRoles"
    ADD CONSTRAINT "FK_AspNetUserRoles_AspNetRoles_RoleId" FOREIGN KEY ("RoleId") REFERENCES public."AspNetRoles"("Id") ON DELETE CASCADE;
 c   ALTER TABLE ONLY public."AspNetUserRoles" DROP CONSTRAINT "FK_AspNetUserRoles_AspNetRoles_RoleId";
       public          postgres    false    208    2890    201            b           2606    24752 5   AspNetUserRoles FK_AspNetUserRoles_AspNetUsers_UserId    FK CONSTRAINT     �   ALTER TABLE ONLY public."AspNetUserRoles"
    ADD CONSTRAINT "FK_AspNetUserRoles_AspNetUsers_UserId" FOREIGN KEY ("UserId") REFERENCES public."AspNetUsers"("Id") ON DELETE CASCADE;
 c   ALTER TABLE ONLY public."AspNetUserRoles" DROP CONSTRAINT "FK_AspNetUserRoles_AspNetUsers_UserId";
       public          postgres    false    208    2894    202            c           2606    24765 7   AspNetUserTokens FK_AspNetUserTokens_AspNetUsers_UserId    FK CONSTRAINT     �   ALTER TABLE ONLY public."AspNetUserTokens"
    ADD CONSTRAINT "FK_AspNetUserTokens_AspNetUsers_UserId" FOREIGN KEY ("UserId") REFERENCES public."AspNetUsers"("Id") ON DELETE CASCADE;
 e   ALTER TABLE ONLY public."AspNetUserTokens" DROP CONSTRAINT "FK_AspNetUserTokens_AspNetUsers_UserId";
       public          postgres    false    202    209    2894            �      x������ � �      �   �   x��1ND1D��.F�;���P���&�i(@��D#M5O�B�`\��	������Y�E����;]�/��tPT����a��CqoQf��g��U�Z����ޠ81��M���I���-YMb(TY
|x�����U/n�%o�.���M6�:���4B������������LXMQ�޷ׅ`S:4g]���R�|�9���CL      �      x������ � �      �      x������ � �      �   I   x���� �w��2 ��K>��	ٕ#��t��	[�7:�ի�˥��fR�|`�h<1uو�M5�{��-.�      �      x������ � �      �   �   x�%��N�0 @��_1����@B�]�d�,ᥗU ht&��b</�<�q�3�`&�.8#�<P��0��@�S�ʦ�6�R���ڪ;�R����6�B�;yB'��ڟ����/=��^�_�-{ѕ#��ɧ�8\~��v���.��鋞�]V6�v]�74�ێ�vǸ����<p�1.
�y/a�l��D,'����_��'@�1M��<Ba      �   +   x�32024400222474����,�L��4�3�34������ �/�     