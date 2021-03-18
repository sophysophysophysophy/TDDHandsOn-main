// 중복된 문자 줄여주는 함수 

// 리팩토링할 때마다 테스트케이스가 피드백을 줌
function refineText(source, options) {
  return [
    normalizeWhitespaces,
    compactWhitespaces,
    maskBannedWords,
    trimWhitespaces,
  ].reduce((value, filter) => filter(value, options), source);
}

function normalizeWhitespaces(value) {
  return value.replace("\t", " ");
}

// indexOf : if not exist -> return -1  
function compactWhitespaces(value) {
  return value.indexOf("  ") < 0
    ? value
    : compactWhitespaces(value.replace("  ", " "));
}

function maskBannedWords(value, options) {
  return options ? options.bannedWords.reduce(maskBannedWord, value) : value;
}

function maskBannedWord(value, bannedWord) {
  return value.replace(bannedWord, "*".repeat(bannedWord.length));
}

function trimWhitespaces(value) {
  return value.trim();
}

module.exports = refineText;
