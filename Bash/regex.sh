text="/a/b/test/x"
if [[ $text =~ (^|/)tests?/ ]]; then
    echo "Match"
else
    echo "Not a match"
fi
