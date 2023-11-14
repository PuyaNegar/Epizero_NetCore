// audio recorder
var recorder, audio_stream;

function startRecording(startRecordiButtonElementId, stopRecordiButtonElementId, audioPlaybackElementId, delegateFunc) {
    $(startRecordiButtonElementId).prop('disabled', true);
    $(startRecordiButtonElementId).text('در حال ضبط ...');
    $(startRecordiButtonElementId).addClass("button-animate");

    $(stopRecordiButtonElementId).removeClass("inactive");
    $(stopRecordiButtonElementId).prop('disabled', false);

    if (!$(audioPlaybackElementId).hasClass("hidden")) {
        $(audioPlaybackElementId).addClass("hidden")
    };
    var preview = document.getElementById(audioPlaybackElementId.replace(/#/g, ''));
    navigator.mediaDevices.getUserMedia({ audio: true })
        .then(function (stream) {
            audio_stream = stream;
            recorder = new MediaRecorder(stream);
            recorder.ondataavailable = function (e) {
                const url = URL.createObjectURL(e.data);
                preview.src = url;
                const blob = new Blob([e.data], { type: 'audio/wav' });
                const reader = new FileReader();
                reader.readAsDataURL(blob);
                reader.onloadend = function () {
                    const base64String = reader.result;

                    if (delegateFunc != null)
                        delegateFunc(base64String);
                }
            };
            recorder.start();

            timeout_status = setTimeout(function () {
                console.log("5 min timeout");
                stopRecording();
            }, 300000);
        });
}
//==========================================
function stopRecording(startRecordiButtonElementId, stopRecordiButtonElementId, audioPlaybackElementId, delegateFunc) {
    recorder.stop();
    audio_stream.getAudioTracks()[0].stop();
    startRecordiButtonElementId.disabled = false;
    $(startRecordiButtonElementId).html(' شروع ضبط <i class="fa fa-microphone" aria-hidden="true"></i>');
    $(startRecordiButtonElementId).removeClass("button-animate");
    $(stopRecordiButtonElementId).addClass("inactive");
    $(stopRecordiButtonElementId).prop('disabled', false);
    $(audioPlaybackElementId).removeClass("hidden");

    if (delegateFunc != null)
        delegateFunc();
}
$(function () {
    $('#answer_removeButton').hide();
 
});


//==========================================
$('body').on('click', '#question_recordButton', function () {
    startRecording('#question_recordButton', this, '#question_audioplayback', function (e) {
        MainViewModel.questionAdd().AudioPath = e;
        $('#question_removeButton').show();
    });
});
//==========================================
$('body').on('click', '#question_stopButton', function () {
    stopRecording('#question_recordButton', this, '#question_audioplayback');
});
//==========================================
$('body').on('click', '#answer_recordButton', function () {
    startRecording('#answer_recordButton', this, '#answer_audioplayback', function (e) {
        MainViewModel.adminAnswerContex().AudioPath = e;
        $('#answer_removeButton').show();
    });
});

//==========================================
$('body').on('click', '#answer_stopButton', function () {
    stopRecording('#answer_recordButton', this, '#answer_audioplayback');
});
//==========================================

$("#stopButton").prop('disabled', true);





