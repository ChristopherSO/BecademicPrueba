var DataSourceTree = function(options) {
	this._data 	= options.data;
	this._delay = options.delay;
}

DataSourceTree.prototype.data = function(options, callback) {
	var self = this;
	var $data = null;

	if(!("name" in options) && !("type" in options)){
		$data = this._data;
		callback({ data: $data });
		return;
	}
	else if("type" in options && options.type == "folder") {
		if("additionalParameters" in options && "children" in options.additionalParameters)
			$data = options.additionalParameters.children;
		else $data = {}
	}
	
	if($data != null)
		setTimeout(function(){callback({ data: $data });} , parseInt(Math.random() * 500) + 200);

};

var tree_data = {
	'modulo-becas' : {name: 'Módulo de Becas', type: 'folder'},
	'modulo-academico' : {name: 'Módulo Académico', type: 'folder'},
	'modulo-reportes' : {name: 'Módulo de reportes', type: 'folder'},
	'modulo-configuracion' : {name: 'Módulo de configuración', type: 'folder'}
}

tree_data['modulo-becas']['additionalParameters'] = {
	'children' : {
		'p1' : {name: 'Solicitar beca', type: 'item'},
		'p2' : {name: 'Emitir veridicto sobre beca', type: 'item'},
		'p3' : {name: 'Crear tipo de beca', type: 'item'},
		'p4' : {name: 'Cambiar tipo de beca', type: 'item'},
		'p5' : {name: 'Borrar tipo de beca', type: 'item'},
		'p6' : {name: 'Crear beneficios', type: 'item'},
		'p7' : {name: 'Crear requisitos', type: 'item'}
	}
}

tree_data['modulo-academico']['additionalParameters'] = {
	'children' : {
		'p8' : {name: 'Administrar carreras', type: 'item'},
		'p9' : {name: 'Administrar cursos', type: 'item'},
		'p10' : {name: 'Administrar calificaciones', type: 'item'},
		'p11' : {name: 'Consultar estudiantes', type: 'item'}
	}
}

tree_data['modulo-reportes']['additionalParameters'] = {
	'children' : {
		'p12' : {name: 'Generar reportes', type: 'item'},
		'p13' : {name: 'Generar proformas', type: 'item'},
		'p14' : {name: 'Generar acta de notas', type: 'item'},
		'p15' : {name: 'Consultar notificaciones', type: 'item'}
	}
}

tree_data['modulo-configuracion']['additionalParameters'] = {
	'children' : {
		'p16' : {name: 'Cambiar configuraciones', type: 'item'}
	}
}

var treeDataSource = new DataSourceTree({data: tree_data});