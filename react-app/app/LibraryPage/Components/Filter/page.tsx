import Styles from './page.module.css'

function Filter() {
    return(
        <div className={Styles.Content}>
            <input type="search" />
            <div className={Styles.Collection}>
                <h4>Genre</h4>
                <div className={Styles.Genres}>
                    <div className={Styles.Gener}>
                        <input type="checkbox" />
                        RPG
                    </div>
                    <div className={Styles.Items}>
                        <input type="checkbox" />
                        Open World
                    </div>
                    <div className={Styles.Item}>
                        <input type="checkbox" />
                        Story Rich
                    </div>
                    <div className={Styles.Gener}>
                        <input type="checkbox" />
                        Atmospheric
                    </div>
                    <div className={Styles.Gener}>
                        <input type="checkbox" />
                        RPG
                    </div>
                    <div className={Styles.Gener}>
                        <input type="checkbox" />
                        RPG
                    </div>
                </div>
            </div>
            <div className={Styles.Collection}>
                <h4>Genre</h4>
                <div className={Styles.Genres}>
                    <div className={Styles.Gener}>
                        <input type="checkbox" />
                        RPG
                    </div>
                    <div className={Styles.Items}>
                        <input type="checkbox" />
                        Open World
                    </div>
                    <div className={Styles.Item}>
                        <input type="checkbox" />
                        Story Rich
                    </div>
                    <div className={Styles.Gener}>
                        <input type="checkbox" />
                        Atmospheric
                    </div>
                    <div className={Styles.Gener}>
                        <input type="checkbox" />
                        RPG
                    </div>
                    <div className={Styles.Gener}>
                        <input type="checkbox" />
                        RPG
                    </div>
                </div>
            </div>
        </div>
    )
}

export default Filter;