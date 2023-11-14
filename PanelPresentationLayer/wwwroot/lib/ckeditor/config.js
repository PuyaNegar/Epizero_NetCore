/**
 * @license Copyright (c) 2003-2020, CKSource - Frederico Knabben. All rights reserved.
 * For licensing, see https://ckeditor.com/legal/ckeditor-oss-license
 */

CKEDITOR.editorConfig = function (config) {
	/*config.extraPlugins = 'html5audio,html5video,ckeditor_wiris';*/
	config.extraPlugins = 'html5audio,html5video';
	config.removePlugins = 'elementspath';
	config.resize_enabled = false;
	config.toolbar = [
		{ name: 'clipboard', items: ['Undo', 'Redo', 'Source' ] },
		{ name: 'basicstyles', items: ['Bold', 'Italic', 'Underline', 'Strike', 'Subscript', 'Superscript' , 'CopyFormatting', 'RemoveFormat'] },
		{ name: 'paragraph', items: ['NumberedList', 'BulletedList', '-', 'Outdent', 'Indent',    'JustifyLeft', 'JustifyCenter', 'JustifyRight', 'JustifyBlock', '-', 'BidiLtr', 'BidiRtl' ] },
/*		{ name: 'insert', items: ['Image', 'Table', 'HorizontalRule', 'Smiley', 'SpecialChar', 'PageBreak', 'Html5audio', 'Html5video', 'ckeditor_wiris_formulaEditor', 'ckeditor_wiris_formulaEditorChemistry'] },*/
		{ name: 'insert', items: ['Image', 'Table', 'HorizontalRule', 'Smiley', 'SpecialChar', 'PageBreak', 'Html5audio', 'Html5video'] },
		{ name: 'colors', items: ['TextColor', 'BGColor'] },
		{ name: 'tools', items: ['Maximize']  },
		{ name: 'other', items: [] },
		{ name: 'styles', items: ['FontSize'] },
	]; 
    // Define changes to default configuration here. For example:
	config.language = 'fa';
	config.height = 200;
    config.skin = 'moono';
    // config.uiColor = '#AADC6E';
    config.contentsLangDirection = 'rtl';
	
	config.allowedContent = true; 
   // config.removeButtons = 'IFrame,Save,Source,Templates,Scayt,Form,Checkbox,Radio,TextField,Textarea,Select,Button,ImageButton,HiddenField,About,ShowBlocks,Language,CreateDiv,ExportPdf,Print,NewPage,Preview,Format,Styles';
};
