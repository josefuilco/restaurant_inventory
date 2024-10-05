INSERT INTO USERS.ROLES (tId_Rol, vNom_Rol)
VALUES 
(1, 'Administrador'),
(2, 'Empleado');

--Password: admin123
INSERT INTO USERS.USERS (vNom_User, vPass_User, vCorreo_User, dFecha_User, bActivo, tId_Rol)
VALUES 
('admin@galindo', 'YWRtaW4xMjM=', 'admin@gmail.com', GETDATE(), 1, 1);

INSERT INTO INVENTARIO.CATEGORIACOMIDA (vNom_CatComida)
VALUES 
('Criollos'),
('Frituras'),
('Postres'),
('Ensaladas'),
('Carnes'),
('Mariscos'),
('Vegetariano'),
('Pastas'),
('Sopas'),
('Bebidas');

INSERT INTO INVENTARIO.UNIDADMEDIDA (vNombre_UniMed)
VALUES 
('Gramos'),
('Kilogramos'),
('Litros'),
('Mililitros'),
('Unidades');

INSERT INTO INVENTARIO.CATEGORIAPRODUCTO (vNom_CatProd, tId_UniMed)
VALUES 
('Carnes', 2),    -- Kilogramos
('Bebidas', 3),   -- Litros
('Verduras', 2),  -- Kilogramos
('Frutas', 2),    -- Unidades
('Mariscos', 2),  -- Kilogramos
('Especias', 1),  -- Gramos
('Salsas', 4),    -- Mililitros
('Lácteos', 5),   -- Unidades
('Granos', 2);    -- Kilogramos

INSERT INTO INVENTARIO.OPERACION (vTipo_Ope, bActivo)
VALUES
('Agregar Producto', 1),
('Eliminar Producto', 2),
('Modificar Producto', 3);